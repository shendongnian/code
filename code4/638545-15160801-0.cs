        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            this.Controls.Add(btn);
            // adtionally set the button location & position
            //register the click handler
            btn.Click += OnClickOfDynamicButton;
        }
        private void OnClickOfDynamicButton(object sender, EventArgs eventArgs)
        {
            //since you dont not need to know which of the created button is click, you just need the text to be ""
            ((Button) sender).Text = string.Empty;
        }
