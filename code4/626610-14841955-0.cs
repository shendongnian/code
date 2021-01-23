        btnA.Click += AppendButtonText;
        btn_a.Click += AppendButtonText;
        ...
 
        private void AppendButtonText(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                lblSentenceText.Text += button.Text;
            }
        }
