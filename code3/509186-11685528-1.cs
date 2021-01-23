    [TemplatePart(Type = typeof(Grid), Name = EditableTextBlock.GRID_NAME)]
    [TemplatePart(Type = typeof(RichTextBox), Name = EditableTextBlock.RICHTEXTBOX_DISPLAYTEXT_NAME)]
    [TemplatePart(Type = typeof(TextBox), Name = EditableTextBlock.TEXTBOX_EDITTEXT_NAME)]
    public class EditableTextBlock : Control
    {
        private const string GRID_NAME = "PART_GridContainer";
        private const string RICHTEXTBOX_DISPLAYTEXT_NAME = "PART_TbDisplayText";
        private const string TEXTBOX_EDITTEXT_NAME = "PART_TbEditText";
        private Grid gridContainer;
        private RichTextBox richTextBox;
        private TextBox textBox;
        static EditableTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditableTextBlock), new FrameworkPropertyMetadata(typeof(EditableTextBlock)));
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.gridContainer = this.Template.FindName(GRID_NAME, this) as Grid;
            if (this.gridContainer != null)
            {
                this.richTextBox = this.gridContainer.Children[0] as RichTextBox;
                this.richTextBox.GotFocus += new RoutedEventHandler(textBoxLostFocus);
                this.textBox = this.gridContainer.Children[1] as TextBox;
                this.textBox.LostFocus += this.richTextBoxGotFocus;
            }
        }
        private void textBoxLostFocus(object sender, RoutedEventArgs e)
        {
            this.richTextBox.Visibility = Visibility.Hidden;
            this.textBox.Visibility = Visibility.Visible;
        }
        private void richTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            this.richTextBox.Visibility = Visibility.Visible;
            this.textBox.Visibility = Visibility.Hidden;
        }
    }
