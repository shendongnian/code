            while (true)
            {
                byte[] buffer = new byte[256];
                var ar = myProcess.StandardOutput.BaseStream.BeginRead(buffer, 0, 256, null, null);
                ar.AsyncWaitHandle.WaitOne();
                var bytesRead = myProcess.StandardOutput.BaseStream.EndRead(ar);
                if (bytesRead > 0)
                {
                    Console.Write(Encoding.ASCII.GetString(buffer, 0, bytesRead));
                }
                else
                {
                    myProcess.WaitForExit();
                    break;
                }
            }
