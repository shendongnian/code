            string[] t = new string[50];
            t = nameCre("TextBox", 5);
            foreach (string s in t)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    Control ctrl = this.Controls.Find(s, true).FirstOrDefault();
                    if (ctrl != null && ctrl is TextBox)
                    {
                        TextBox tb = ctrl as TextBox;
                        tb.Text = "";
                    }
                }
            }
