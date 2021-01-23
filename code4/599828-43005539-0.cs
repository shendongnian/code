    public class TextBoxAppender : AppenderSkeleton
        {
            public RichTextBox RichTextBox { get; set; }
    
            protected override void Append(LoggingEvent loggingEvent)
            {
                Action operation = () => { this.RichTextBox.AppendText(RenderLoggingEvent(loggingEvent)); };
                this.RichTextBox.Invoke(operation);
            }
        }
