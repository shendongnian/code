           int leftStart = 0;
			 int topStart = 0;
			 
			 using (StreamReader reader = File.OpenText(Server.MapPath(@daoWordPuzzle.GetfileURL())))
       {
           string line;
           while((line =reader.ReadLine()) !=null)             
           {
             //  Response.Write(line + " <br />"); // Read every line in text file.
                  string[] lol =   line.Split(new string[] {","}, StringSplitOptions.None);
                 foreach (var value in lol)
                  { 
                     int i = 0;
                     TextBox tb = new TextBox();
                     tb.MaxLength = (1);
                     tb.Width = Unit.Pixel(40);
                     tb.Height = Unit.Pixel(40);
										 tb.Left = leftStart;
										 tb.Top = topStart;
                     tb.ID = i.ToString();
                    // Response.Write(value);
                     if (string.IsNullOrEmpty(value))
                     {
                         tb.Style["visibility"] = "hidden";
                     }
                     if (!string.IsNullOrEmpty(value))
                     {
                         tb.Text = "";
                     }
                     Panel1.Controls.Add(tb);
                     i++;
										 leftStart = leftStart + 50;
                  }
									topStart = topStart + 50;
                                     leftStart = 0;
           }
       }
