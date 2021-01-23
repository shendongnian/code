            for (int i = 1; i <= indulok + 1; i++)
            {
                if (this.Controls.ContainsKey("textBox" + i.ToString()))
                {
                    TextBox txtBox = this.Controls["textBox" + i.ToString()] as TextBox;
                    if (txtBox != null)
                    {
                        string FileName = "C:\\" + i.ToString() + ".txt";
                        System.IO.File.WriteAllText(FileName, txtBox.Text);
                    }
                }
            }
