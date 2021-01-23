    string sqlgetprint = "SELECT  Service_No,Full_name, Acc_No, OP_date, On_time, Off_time, OP_hours, Payment  FROM   Print_Op ORDER BY Service_No , OP_date";
                DataTable dtall = db.GetData(sqlgetprint);
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel Documents (*.xls)|*.xls";
                saveFileDialog1.FileName = "Employee Details.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fname = saveFileDialog1.FileName;
                    StreamWriter wr = new StreamWriter(fname);
                    for (int i = 0; i < dtall.Columns.Count; i++)
                    {
                        wr.Write(dtall.Columns[i].ToString().ToUpper() + "\t");
                    }
                    wr.WriteLine();
                    //write rows to excel file
                    for (int i = 0; i < (dtall.Rows.Count); i++)
                    {
                        for (int j = 0; j < dtall.Columns.Count; j++)
                        {
                            if (dtall.Rows[i][j] != null)
                            {
                                wr.Write(Convert.ToString(dtall.Rows[i][j]) + "\t");
                            }
                            else
                            {
                                wr.Write("\t");
                            }
                        }
                        //go to next line
                        wr.WriteLine();
                    }
                    //close file
                    wr.Close();
                    if (File.Exists(fname))
                    {
                        System.Diagnostics.Process.Start(fname);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Create Excel Sheet!");
            }
