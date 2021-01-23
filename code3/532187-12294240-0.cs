          int f = 0;
     var reader = new StreamReader(File.OpenRead(@ExcelFilePath));
                    Buisness_logic bl = new Buisness_logic();
                    while (!reader.EndOfStream)
                    {
                           if (f == 0)
                        {
                             var line = reader.ReadLine();
                            f++;
                        }
                        else
                        {
                            var line = reader.ReadLine();
                            string[] s = line.Split(',');
                            count = s.Length;
                            if (s.Length == 3)
                            {
                                var values = line.Split(',');
                                string query = "Insert into Events_party values('" + identity + "','" + values[0] + "','" + values[1] + "','" + values[2] + "','" + time + "','" + dt + "')";
                                bl.ExecuteQuery(query);
                                count = 101;
                            }
                            else
                            {
                                MessageBox.Show("Imported File was not in defined format !! ", ".File Format Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                textBox1.BackColor = Color.Pink;
                                break;
                                count = 100;
                            }
                        }
                    }
