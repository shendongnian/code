            using (OracleCommand crtCommand = new OracleCommand(myCommand, conn1))
            {
                using (OracleDataReader reader = crtCommand.ExecuteReader())
                {
                    reader.Read();
                    string[] splitted = reader[0].ToString().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in splitted)
                    {
                        richTextBox1.AppendText(Environment.NewLine + line.Trim() + ";" + Environment.NewLine);
                    }
                }
            }
