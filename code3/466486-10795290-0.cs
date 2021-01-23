           try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileName = openFileDialog1.FileName;
                    
                    string FName = FileName;
                    int a = FileName.LastIndexOf('\\');
                    txtFileName.Text = FileName.Substring(a + 1);
                    axAcroPDF1.LoadFile(FileName);
                    FileInfo fi = new FileInfo(FileName);
                    string PDFFileName = fi.Name.ToString();
                    double filesize = (fi.Length / 1024F / 1024F);
                    string size = filesize.ToString("0.00 MB");
                    string CreationDate = fi.CreationTime.ToString();
                    string LastAccessDate = fi.LastAccessTime.ToString();
                    string ModifiedDate = fi.LastWriteTime.ToString();
                    lblVersion.Text = "File Name         : " + PDFFileName + "\nSize                  : " + size + "\nCreation Date   : " + CreationDate + "\nModified Date   : " + ModifiedDate;
                    TextExtractor extractor = new TextExtractor();
                    extractor.RegistrationName = "Demo";
                    extractor.RegistrationKey = "Demo";
                    extractor.LoadDocumentFromFile(FileName);
                    int pageCount = extractor.GetPageCount();
                   
                    RectangleF location;
                    for (int s = 0; s <= Keywords.Length - 1; s++)
                    {
                       
                        
                        if (Keywords[s] != "")
                        {
                            TreeNode tNode = new TreeNode();
                            tNode = treeView1.Nodes.Add(Keywords[s]);
                            
                            for (int i = 0; i < pageCount; i++)
                            {
                                if (extractor.Find(i, Keywords[s], false, out location))
                                {
                                    do
                                    {
                                        int j = i;
                                        tNode.Nodes.Add((j+1).ToString() + "     " + location.ToString());
                                        float X = location.X;
                                        float Y = location.Y;
                                        float Width = location.Width;  
                                        float Height = location.Height;
                                        
                                        float Left = location.Left;
                                        float Right = location.Right;
                                        float Top = location.Top;
                                        float Bottom = location.Bottom;
                                        
                                        
                                        //axAcroPDF1.setCurrentHighlight(Convert.ToInt32(X), Convert.ToInt32(Y), Convert.ToInt32(Width), Convert.ToInt32(Height));
                                        
                                    }
                                    while (extractor.FindNext(out location));
                                }
                            }
                        }
                        else
                        {
                            
                        }
                    }      
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
