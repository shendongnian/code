            string targetPath = BatchFolderPath + @"\" + "TRANSACT.INX";
            StreamWriter wrtr = null;
            wrtr = new StreamWriter(targetPath);
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                string rowString = "";
                for (int y = 0; y < dt.Columns.Count; y++)
                {
                    string dateTimeString = dt.Rows[x][y].ToString();
                    DateTime dateTime;
                    if (DateTime.TryParse(dateTimeString, out dateTime))
                    {
                        string formattedDate = dateTime.ToString("dd/MM/yyyy");
                        if (y == dt.Columns.Count - 1)
                        {
                            rowString += "\"" + formattedDate + "\"";
                        }
                        else
                        {
                            rowString += "\"" + formattedDate + "\"~";
                        }
                    }
                }
                rowString = rowString.Replace("\"", String.Empty).Trim();
                wrtr.WriteLine(rowString);
            }
            wrtr.Close();
            wrtr.Dispose();
