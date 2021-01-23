        public string OldValue = string.Empty;
        public char UpdateChar;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var newText = sender as TextBox;
            
            foreach (var val in newText.Text)
            {
                if(!OldValue.ToCharArray().Contains(val))
                    UpdateChar = val;
            }
            OldValue = newText.Text;
        }
