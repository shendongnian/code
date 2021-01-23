        using (StreamReader Reader = new StreamReader(@"C:\Original_Text_File.txt"))
        {
            StringBuilder aLine;
            boolean first = true;
            while (!Reader.EndOfStream)
            {
               // read source line
               string inLine = Reader.ReadLine();
               // if length is zero append to test box (we have a blank line between records)
               if (inLine.Length == 0)
               {
                  TextBox1.AppendText(aLine.ToString());
                  first = true;
               } 
               // add a comma if we are not the first
               if (!first)
               {
                 aLine.Append(",");
               }
               aLine.Append(inLine);
               // next time we won't be first
               first = false;
            }
            TextBox1.AppendText(aLine.ToString());
        }           
