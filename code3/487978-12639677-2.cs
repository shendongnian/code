    <UserControl x:Class="WpfTestApp.Xml.XmlEditor"
                    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:avalonedit="http://icsharpcode.net/sharpdevelop/avalonedit"
                    xmlns:WpfTestApp="clr-namespace:WpfTestApp.Xml">
        <UserControl.CommandBindings>
            <CommandBinding Command="WpfTestApp:XmlEditor.ValidateCommand" Executed="Validate"/>
        </UserControl.CommandBindings>
        <avalonedit:TextEditor Name="textEditor" FontFamily="Consolas" SyntaxHighlighting="XML" FontSize="8pt">
            <avalonedit:TextEditor.Options>
                <avalonedit:TextEditorOptions ShowSpaces="True" ShowTabs="True"/>
            </avalonedit:TextEditor.Options>
            <avalonedit:TextEditor.ContextMenu>
                <ContextMenu>
                    <MenuItem Command="Undo" />
                    <MenuItem Command="Redo" />
                    <Separator/>
                    <MenuItem Command="Cut" />
                    <MenuItem Command="Copy" />
                    <MenuItem Command="Paste" />
                    <Separator/>
                    <MenuItem Command="WpfTestApp:XmlEditor.ValidateCommand" />
                </ContextMenu>
            </avalonedit:TextEditor.ContextMenu>
        </avalonedit:TextEditor>
    </UserControl>
.
    public partial class XmlEditor : UserControl
    {
        private static readonly ICommand validateCommand = new RoutedUICommand("Validate XML", "Validate", typeof(MainWindow),
            new InputGestureCollection { new KeyGesture(Key.V, ModifierKeys.Control | ModifierKeys.Shift) });
        private readonly TextMarkerService textMarkerService;
        private ToolTip toolTip;
        public static ICommand ValidateCommand
        {
            get { return validateCommand; }
        }
        public XmlEditor()
        {
            InitializeComponent();
            textMarkerService = new TextMarkerService(textEditor);
            TextView textView = textEditor.TextArea.TextView;
            textView.BackgroundRenderers.Add(textMarkerService);
            textView.LineTransformers.Add(textMarkerService);
            textView.Services.AddService(typeof(TextMarkerService), textMarkerService);
            textView.MouseHover += MouseHover;
            textView.MouseHoverStopped += TextEditorMouseHoverStopped;
            textView.VisualLinesChanged += VisualLinesChanged;
        }
        private void MouseHover(object sender, MouseEventArgs e)
        {
            var pos = textEditor.TextArea.TextView.GetPositionFloor(e.GetPosition(textEditor.TextArea.TextView) + textEditor.TextArea.TextView.ScrollOffset);
            bool inDocument = pos.HasValue;
            if (inDocument)
            {
                TextLocation logicalPosition = pos.Value.Location;
                int offset = textEditor.Document.GetOffset(logicalPosition);
                var markersAtOffset = textMarkerService.GetMarkersAtOffset(offset);
                TextMarkerService.TextMarker markerWithToolTip = markersAtOffset.FirstOrDefault(marker => marker.ToolTip != null);
                if (markerWithToolTip != null)
                {
                    if (toolTip == null)
                    {
                        toolTip = new ToolTip();
                        toolTip.Closed += ToolTipClosed;
                        toolTip.PlacementTarget = this;
                        toolTip.Content = new TextBlock
                        {
                            Text = markerWithToolTip.ToolTip,
                            TextWrapping = TextWrapping.Wrap
                        };
                        toolTip.IsOpen = true;
                        e.Handled = true;
                    }
                }
            }
        }
        void ToolTipClosed(object sender, RoutedEventArgs e)
        {
            toolTip = null;
        }
        void TextEditorMouseHoverStopped(object sender, MouseEventArgs e)
        {
            if (toolTip != null)
            {
                toolTip.IsOpen = false;
                e.Handled = true;
            }
        }
        private void VisualLinesChanged(object sender, EventArgs e)
        {
                if (toolTip != null)
                {
                        toolTip.IsOpen = false;
                }
        }
        private void Validate(object sender, ExecutedRoutedEventArgs e)
        {
            IServiceProvider sp = textEditor;
            var markerService = (TextMarkerService)sp.GetService(typeof(TextMarkerService));
            markerService.Clear();
            try
            {
                var document = new XmlDocument { XmlResolver = null };
                document.LoadXml(textEditor.Document.Text);
            }
            catch (XmlException ex)
            {
                DisplayValidationError(ex.Message, ex.LinePosition, ex.LineNumber);
            }
        }
        private void DisplayValidationError(string message, int linePosition, int lineNumber)
        {
            if (lineNumber >= 1 && lineNumber <= textEditor.Document.LineCount)
            {
                int offset = textEditor.Document.GetOffset(new TextLocation(lineNumber, linePosition));
                int endOffset = TextUtilities.GetNextCaretPosition(textEditor.Document, offset, System.Windows.Documents.LogicalDirection.Forward, CaretPositioningMode.WordBorderOrSymbol);
                if (endOffset < 0)
                {
                    endOffset = textEditor.Document.TextLength;
                }
                int length = endOffset - offset;
                if (length < 2)
                {
                    length = Math.Min(2, textEditor.Document.TextLength - offset);
                }
                textMarkerService.Create(offset, length, message);
            }
        }
    }
