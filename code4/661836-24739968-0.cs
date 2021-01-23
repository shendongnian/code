                   SaveFileDialog SD = new SaveFileDialog();
                    if (SD.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                    {
                        System.IO.StreamWriter SW = new System.IO.StreamWriter(SD.FileName);
                        foreach (string str in checkedListBox1.CheckedItems)
                        {
                            string XMLSTR = //Heads.funtions.ConvertDatatableToXML(
                                            Heads.funtions.fire_qry_for_string(string.Format("Select * from {0} FOR XML AUTO,TYPE, ELEMENTS ,ROOT('{0}')", str)); // , str);
                            SW.Write(XMLSTR);
                            SW.WriteLine("###TABLEEND###");
                        }
                        SW.Close();
                        //_CommonClasses._Cls_Alerts.ShowAlert("Clean Up Completed...!!!", "CleanUP", MessageBoxIcon.Information);
                    }
                
