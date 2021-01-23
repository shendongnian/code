    using (SqlConnection Conn = new SqlConnection(strSQLConn))
            {
                
                ////Create a DataAdapter
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //// a Table mapping name the DataTable.
                //adapter.TableMappings.Add("Table", "OneDayRecords");
                //open the connection
                Conn.Open();
                Console.WriteLine("the connection is open");
                //Variables needed for looping
                DateTime Today = System.DateTime.Now;
                DateTime StartDate = Convert.ToDateTime("2008-06-11 00:00:00");
                //DateTime StartDate = Today.AddDays(-10);
                Console.WriteLine("Converting the Documents from " + StartDate.ToString() + " - TO - " + Today.ToString());
                Console.WriteLine("Press Any Key to continue.");
                Console.ReadLine();
                int RecordCount = 0;
                ulong ByteCount = 0;
                int i = 1;
                foreach (DateTime day in EachDay(StartDate, Today))
                {
                    String strDay = day.ToString();
                    // Create a SQLCommand to retrieve Data
                    SqlCommand getRecords = new SqlCommand("spRecapturePDF", Conn);
                    getRecords.CommandType = CommandType.StoredProcedure;
                    getRecords.Parameters.Add(new SqlParameter("@OneDay", strDay));
                    SqlDataReader reader = getRecords.ExecuteReader();
                    //stuff exporting the binary code to the PDF format
                    FileStream fs;
                    BinaryWriter bw;
                    int buffersize = 100;
                    byte[] outbyte = new byte[buffersize];
                    long retval;
                    long startIndex = 0;
                    int j = 1;
    
                    while (reader.Read())
                    {
                        strFileName = reader.GetString(0) + "-" + i + "-" + j;
                        strDock_no = reader.GetString(0);
                        dtFiledate = reader.GetDateTime(2);
                        strDescription = reader.GetString(4);
                        
                        fs = new FileStream("c:\\FolderName\\" + strFileName + ".pdf", FileMode.OpenOrCreate, FileAccess.Write);
                        bw = new BinaryWriter(fs);
                        startIndex = 0;
                        retval = reader.GetBytes(1,startIndex,outbyte,0,buffersize);
                        while (retval == buffersize)
                        {
                            bw.Write(outbyte);
                            bw.Flush();
                            startIndex += buffersize;
                            retval = reader.GetBytes(1,startIndex,outbyte,0,buffersize);
                        }
                        //write the remaining buffer.
                        bw.Write(outbyte,0,(int)retval);
                        ByteCount = ByteCount + Convert.ToUInt64(fs.Length);
                        bw.Flush();
                        //close the output file
                        bw.Close();
                        fs.Close();
                        //need to write to the Text file here.
                        TextWriter tw = new StreamWriter(path,true);
                        
                        tw.WriteLine(strDock_no + "~" + dtFiledate.ToString() + "~" + "c:\\FolderName\\" + strFileName + ".pdf" + "~" + strDescription);
                        tw.Close();
                        // increment the J variable for the Next FileName
                        j++;
                        RecordCount++;
                    }
                 //close the reader and the connection
                    reader.Close();
                    i++;
                }
            Console.WriteLine("Number of Records Processed:  " + RecordCount.ToString());
                Console.WriteLine("for a Total of : " + ByteCount + " Bytes");
                Decimal MByteCount = new Decimal(2);
                MByteCount = Convert.ToDecimal(ByteCount) / 1024 / 1024;
                Decimal GByteCount = new Decimal(2);
                GByteCount = MByteCount / 1024;
                Console.WriteLine("Total MBs : " + MByteCount.ToString() + " MB");
                Console.WriteLine("Total GBs : " + GByteCount.ToString() + " GB");
                Console.WriteLine("Press Enter to Continue ...");
                Console.ReadLine();
            }
