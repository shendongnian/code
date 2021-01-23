     StreamWriter swOut =  new StreamWriter(file);
                            swOut.AutoFlush = true;
                            if (table.Rows.Count == 2)
                            {
                                for (int i = 0; i <= table.Columns.Count - 1; i++)
                                {
                                    if (i > 0)
                                    {
                                        swOut.Write(",");
                                    }
                                    swOut.Write(table.Columns[i].HeaderText);
                                }
                                swOut.WriteLine();
                            }
                            swOut.Write(category.Replace(",", " ") + "," + name.Replace(",", " ") + "," + address.Replace(",", " ") + "," + locality.Replace(",", " ") + "," + cap.Replace(",", " ") + "," + tel.Replace(",", " ") + "," + fax.Replace(",", " ") + "," + www.Replace(",", " ") + "," + email_results.Replace(",", " ") + "," + business_url.Replace(",", " ") + "," + map_query.Replace(",", " "));
                            swOut.WriteLine();
                            swOut.Close();
                            file.Close();
                            file = new FileStream(output_file, FileMode.Append, FileAccess.Write, FileShare.Read);
                            //file.Lock(0, file.Length);
