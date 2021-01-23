                    //rec = 0;
                    //do
                    //{
                    //    if (client.Poll(3000 * 1000, SelectMode.SelectRead))
                    //    {
                    //        rec = client.Receive(buffer, buffer.Length, SocketFlags.None);
                    //        Debug.Print("RECEIVED FROM CLIENT: " + Encoding.ASCII.GetString(buffer, 0, rec));
                    //        sent = webserver.Send(buffer, rec, SocketFlags.None);
                    //        Debug.Print("SENT TO WEBSERVER[" + sent.ToString() + "]: " + Encoding.ASCII.GetString(buffer, 0, rec));
                    //        transferred += rec;
                    //    }
                    //    else
                    //    {
                    //        Debug.Print("No data polled from client");
                    //    }
                    //} while (rec == buffer.Length);
                    //Debug.Print("loop-2 finished");
