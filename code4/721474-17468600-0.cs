        this.textBoxPin.TextChanged += delegate(object sender, EventArgs e)
        {
            String pattern = @"[0-9]{4,}";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(textBoxPin.Text))
            {
                buttonOK.Enabled = true;
            }
            else
            {
                buttonOK.Enabled = false;
            }
        };
?
