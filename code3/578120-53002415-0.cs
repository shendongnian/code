    - //-------------------------------------------------------------------
                               // Create an instance of the Printer
                               IPrinter printer = new Printer();
               
                               //----------------------------------------------------------------------------
                               String path = @"" + file_browse_path.Text;
                             //  using (StreamReader sr = File.OpenText(path))
               
                               using (StreamReader sr = new System.IO.StreamReader(path))
                               {
                                  
                                  string fileLocMove="";
                                  string newpath = Path.GetDirectoryName(path);
                                   fileLocMove = newpath + "\\" + "new.prn";
               
                               
               
                                      string text = File.ReadAllText(path);
                                      text= text.Replace("<REF>", reference_code.Text);
                                      text=   text.Replace("<ORANGE>", orange_name.Text);
                                      text=   text.Replace("<SIZE>", size_name.Text);
                                      text=   text.Replace("<INVOICE>", invoiceName.Text);
                                      text=   text.Replace("<BINQTY>", binQty.Text);
                                      text = text.Replace("<DATED>", dateName.Text);
                                  
                                           File.WriteAllText(fileLocMove, text);
                                    
               
               
                                   // Print the file
                                   printer.PrintRawFile("Godex G500", fileLocMove, "n");
                                  // File.WriteAllText("C:\\Users\\Gunjan\\Desktop\\new.prn", s);
                               }
