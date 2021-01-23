            for (int i = 1; i <= indulok + 1; i++)
            {
                Control[] controls = this.Controls.Find("txtBox" + i.ToString(), true);
                if (controls.Length > 0)
                {
                    TextBox txtBox = controls[0] as TextBox;
                    if (txtBox != null)
                    {
                        string FileName = "C:\\" + i.ToString() + ".txt";
                        System.IO.File.WriteAllText(FileName, txtBox.Text);
                    }
                }
            }
