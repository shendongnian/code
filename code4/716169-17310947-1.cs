    int leftStart = 0;
            int topStart = 0;
            using (StreamReader reader = File.OpenText(@"C:\\hello.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //  Response.Write(line + " <br />"); // Read every line in text file.
                    string[] lol = line.Split(new string[] { "," }, StringSplitOptions.None);
                    foreach (var value in lol)
                    {
                        int i = 0;
                        TextBox tb = new TextBox();
                        tb.MaxLength = (1);
                        tb.Width = 40;
                        tb.Height = 40;
                        tb.Left = leftStart;
                        tb.Top = topStart;
                        tb.Visible = true;
                        // Response.Write(value);
                        if (string.IsNullOrEmpty(value))
                        {
                            //tb.Style["visibility"] = "hidden";
                            tb.Visible = false;
                        }
                        if (!string.IsNullOrEmpty(value))
                        {
                            tb.Text = "";
                        }
                        panel1.Controls.Add(tb);
                        i++;
                        leftStart = leftStart + 50;
                    }
                    topStart = topStart + 50;
                    leftStart = 0;
                }
            }
