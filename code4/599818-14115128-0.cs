    public class TextBoxAppender : AppenderSkeleton
    {
        private TextBox _textBox;
        public string FormName { get; set; }
        public string TextBoxName { get; set; }
    
        protected override void Append(LoggingEvent loggingEvent)
        {
            if (_textBox == null)
            {
                if (String.IsNullOrEmpty(FormName) || 
                    String.IsNullOrEmpty(TextBoxName))
                    return;
    
                Form form = Application.OpenForms[FormName];
                if (form == null)
                    return;
    
                _textBox = form.Controls.OfType<TextBox>()
                               .Where(tb => tb.Name == TextBoxName)
                               .SingleOrDefault();
                if (_textBox == null)
                    return;
    
                form.FormClosing += (s, e) => _textBox = null;
            }
    
            _textBox.AppendText(loggingEvent.RenderedMessage + Environment.NewLine);
        }
    }
