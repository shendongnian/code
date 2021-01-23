            var sbText = new System.Text.StringBuilder(10000);
            // Keeps track of your current position within a record
            int wCurrLine = 0;
            // Number of rows in the file that constitute a record
            const int LINES_PER_ROW = 12;
            using (StreamReader Reader = new StreamReader(@"C:\Original_Text_File.txt"))
            {
                while (!Reader.EndOfStream)
                {
                    // If we are not on the first row in the record, add a comma
                    if (wCurrLine != 0)
                    {
                        sbText.Append(",");
                    }
                    // Add the text
                    sbText.Append(Reader.ReadLine());
                    // Increment our current record row counter
                    wCurrLine++;
                    // If we have read all of the rows for this record
                    if (wCurrLine == LINES_PER_ROW)
                    {
                        // Add a line to our buffer
                        sbText.AppendLine();
                        // And reset our record row count
                        wCurrLine = 0;
                    }
                }
                // When all of the data has been loaded, write it to the text box in one fell swoop
                TextBox1.Text = sbText.ToString();
