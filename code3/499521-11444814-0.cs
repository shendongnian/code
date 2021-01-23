            string[] t = new string[50];
            t = nameCre("TextBox", 5);
            foreach (string s in t)
            {
                var tb = this.Controls.Find(s, true).FirstOrDefault();
                if (tb != null && tb is TextBox)
                {
                    tb = tb as TextBox;
                    tb.Text = "";
                }
            }
