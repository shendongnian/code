            for (int i = 1; i <= indulok + 1; i++)
            {
                if (this.Controls.ContainsKey("textBox" + i.ToString()))
                {
                    TextBox txtBox = this.Controls["textBox" + i.ToString()] as TextBox;
                    if (txtBox != null)
                    {
                        txtBox.Text = "New text";
                    }
                }
            }
