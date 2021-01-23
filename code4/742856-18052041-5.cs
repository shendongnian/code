    try
            {
                // create an instance of TcpClient
                string str = string.Empty;
                string strTemp = string.Empty;
                TcpClient tcpclient = new TcpClient();
                // HOST NAME POP SERVER and gmail uses port number 995 for POP
                tcpclient.Connect("pop.gmail.com", 995);
                // This is Secure Stream // opened the connection between client and POP Server
                System.Net.Security.SslStream sslstream = new SslStream(tcpclient.GetStream());
                // authenticate as client  
                sslstream.AuthenticateAsClient("pop.gmail.com");
                //bool flag = sslstream.IsAuthenticated;   // check flag
                // Asssigned the writer to stream 
                System.IO.StreamWriter sw = new StreamWriter(sslstream);
                // Assigned reader to stream
                System.IO.StreamReader reader = new StreamReader(sslstream);
                strTemp = reader.ReadLine();
                // refer POP rfc command, there very few around 6-9 command
                
                sw.WriteLine("USER user@gmail.com");
                
                // sent to server
                sw.Flush();
                strTemp = reader.ReadLine();
                sw.WriteLine("PASS password");
                
                sw.Flush();
                strTemp = reader.ReadLine();
                
                // RETR 1 will retrive your first email. it will read content of your first email
                sw.WriteLine("RETR 1");
                sw.Flush();
                strTemp = reader.ReadLine();
                while ((strTemp = reader.ReadLine()) != null)
                {
                    // find the . character in line
                    if (strTemp == ".")
                    {
                        break;
                    }
                    if (strTemp.IndexOf("-ERR") != -1)
                    {
                        break;
                    }
                    str += strTemp;
                }
                // close the connection
                sw.WriteLine("Quit ");
                sw.Flush(); 
                while ((strTemp = reader.ReadLine()) != null)
                {
                    // find the . character in line
                    if (strTemp == ".")
                    {
                        break;
                    }
                    if (strTemp.IndexOf("-ERR") != -1)
                    {
                        break;
                    }
                    str += strTemp;
                }
                //  textBox1.Text ="Congratulation.. ....!!! You read your first gmail email ";
            }
            catch (Exception ex)
            {
                
            }
