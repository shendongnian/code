    public class MyTextBox : TextBox
    {
        private Label cueLabel;
        public TextBoxWithLabel()
        {
            SuspendLayout();
            cueLabel = new Label();
            cueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cueLabel.AutoSize = true;
            cueLabel.Text = "Enter your name";
            Controls.Add(cueLabel);
            cueLabel.Location = new Point(Width - cueLabel.Width, 0);
            ResumeLayout(false);
            PerformLayout();
        }
    }
