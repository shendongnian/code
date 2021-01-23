    void serialTxtBox_TextChanged(object sender, EventArgs e)
            {
                bool enteredLetter = false;
                Queue<char> text = new Queue<char>();
                foreach (var ch in this.serialTxtBox.Text)
                {
                    if (char.IsDigit(ch))
                    {
                        text.Enqueue(ch);
                    }
                    else
                    {
                        enteredLetter = true;
                    }
                }
                if (enteredLetter)
                {
                    StringBuilder sb = new StringBuilder();
                    while (text.Count > 0)
                    {
                        sb.Append(text.Dequeue());
                    }                
    
                    this.serialTxtBox.Text = sb.ToString();
                    this.serialTxtBox.SelectionStart = this.serialTxtBox.Text.Length;
                }
            }
