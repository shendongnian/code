       //Stream is a base class it holds the reference of MemoryStream
                Stream stream = new MemoryStream();
                String strText = "This is a String that needs to beconvert in stream";
                 byte[] byteArray = Encoding.UTF8.GetBytes(strText);
                 stream.Write(byteArray, 0, byteArray.Length);
                 //set the position at the beginning.
                 stream.Position = 0;
                 using (StreamReader sr = new StreamReader(stream))
                            {
                               string strData;
                               while ((strData= sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(strData);
                                }
                            }
