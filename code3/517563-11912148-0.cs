                ListViewItem item = lvwMessages.SelectedItems[0];
                if(item.Font.Bold)
                    {
                        lvwMessages.SelectedItems[0].Font = new Font(lvwMessages.Font, FontStyle.Regular);
                        string tfile = File.ReadAllText("C:\\message.txt");
                        string m1 = lvwMessages.SelectedItems[0].SubItems[1].Text;
                        string m2 = lvwMessages.SelectedItems[0].SubItems[2].Text;
                        string line = string.Empty;
                        string nfile= "";
                        using (StreamReader sr = new StreamReader("C:\\message.txt"))
                        {
                          while ((line = sr.ReadLine()) != null)
                          {
                              if (line.Contains(m2)) 
                              {
                                  string pline = line;
                                 string result = line.Replace("REC UNREAD", "REC READ");
                                 nfile= tfile.Replace(pline, result);
                              }
                           }
                       sr.Close();
                       }
                    StreamWriter sw = new StreamWriter("C:\\message.txt");
                    {
                        sw.Write(nfile);
                    }
                    sw.Close();                           
                }
