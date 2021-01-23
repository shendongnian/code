        private void txt_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Unknown)
            {
                txt.Text = txt.Text.Replace('.', ',');
                
                // reset cursor position to the end of the text (replacing the text will place
                // the cursor at the start)
                txt.Select(txt.Text.Length, 0);
            }
        } 
