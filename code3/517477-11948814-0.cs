                    DialogResult result1 = MessageBox.Show("Are you sure to delete?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result1.Equals(DialogResult.Yes))
                    {
                        string re1 = "";
                        string re2 = "";
                        string replacedata = filedata;
                        for (int i = 0; i < lvwMessages.Items.Count; i++)
                        {
                            if (lvwMessages.Items[i].Checked)
                            {
                                re1 = lvwMessages.CheckedItems[0].SubItems[1].Text;
                                re2 = lvwMessages.CheckedItems[0].SubItems[2].Text;
                                replacedata = replacedata.Replace(re1 + re2, "");
                                lvwMessages.Items[i].Remove();
                                i--;
                            }
                        }
                        StreamWriter sw = new StreamWriter("C:\\message.txt");
                        sw.Write(replacedata);
                        sw.Close();
                        
                    }
