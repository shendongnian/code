    List<string> TextBoxesName=new List<string>();
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBoxesName.Add((item as TextBox).Text);
                    }
                }
