     using (StreamReader sr = new StreamReader("C://File.txt"))
            {
                String line;
                int index = -1;
                while ((line = sr.ReadLine()) != null)
                {
                    index++;
                    iIndexofComma = line.IndexOf(@",");
                    iLength = line.Length;
                    dt.Rows.Add();
                    dt.Rows[index]["col1"] = line.Substring(0, iIndexofComma);
                    dt.Rows[index]["col2"] = line.Substring(iIndexofComma + 1, iLength - iIndexofComma - 1);
                    dtMapping.AcceptChanges();
                }
            }
