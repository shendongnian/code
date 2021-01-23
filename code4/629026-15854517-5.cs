    public class AvalonTextEditor : TextEditor
    {
        #region EditText Dependency Property
        public static readonly DependencyProperty EditTextProperty =
            DependencyProperty.Register(
            "EditText",
            typeof(string),
            typeof(AvalonTextEditor),
            new UIPropertyMetadata(string.Empty, EditTextPropertyChanged));
        private static void EditTextPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            AvalonTextEditor editor = (AvalonTextEditor)sender;
            editor.Text = (string)e.NewValue;
        }
        public string EditText
        {
            get { return (string)GetValue(EditTextProperty); }
            set { SetValue(EditTextProperty, value); }
        }
        #endregion
        #region TextEditor Property
        public static TextEditor GetTextEditor(ContextMenu menu) { return (TextEditor)menu.GetValue(TextEditorProperty); }
        public static void SetTextEditor(ContextMenu menu, TextEditor value) { menu.SetValue(TextEditorProperty, value); }
        public static readonly DependencyProperty TextEditorProperty =
            DependencyProperty.RegisterAttached("TextEditor", typeof(TextEditor), typeof(AvalonTextEditor), new UIPropertyMetadata(null, OnTextEditorChanged));
        static void OnTextEditorChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            ContextMenu menu = depObj as ContextMenu;
            if (menu == null || e.NewValue is DependencyObject == false)
                return;
            TextEditor editor = (TextEditor)e.NewValue;
            NameScope.SetNameScope(menu, NameScope.GetNameScope(editor));
        }
        #endregion
        public AvalonTextEditor()
        {
            this.Loaded += new RoutedEventHandler(AvalonTextEditor_Loaded);
        }
        void AvalonTextEditor_Loaded(object sender, RoutedEventArgs e)
        {
            this.ContextMenu.SetValue(AvalonTextEditor.TextEditorProperty, this);
        }
    }
    public class AvalonRelayCommand : ICommand
    {
        readonly RoutedCommand _routedCommand;
        public string Text { get; set; }
        public AvalonRelayCommand(RoutedCommand routedCommand) { _routedCommand = routedCommand; }
        public event EventHandler CanExecuteChanged { add { CommandManager.RequerySuggested += value; } remove { CommandManager.RequerySuggested -= value; } }
        public bool CanExecute(object parameter) { return _routedCommand.CanExecute(parameter, GetTextArea(GetEditor(parameter))); }
        public void Execute(object parameter) { _routedCommand.Execute(parameter, GetTextArea(GetEditor(parameter))); }
        private AvalonTextEditor GetEditor(object param)
        {
            var contextMenu = param as ContextMenu;
            if (contextMenu == null) return null;
            var editor = contextMenu.GetValue(AvalonTextEditor.TextEditorProperty) as AvalonTextEditor;
            return editor;
        }
        private static TextArea GetTextArea(AvalonTextEditor editor)
        {
            return editor == null ? null : editor.TextArea;
        }
    }
