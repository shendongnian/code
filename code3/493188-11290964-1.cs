    string saveTo1 = savePath + @"\" + filename[i];
    byte[] buffer = new byte[32768];
    try
    {
                using (Stream input = getResponse.GetResponseStream())
                {
                    using (FileStream output = new FileStream(saveTo1, FileMode.OpenOrCreate))
                    {
                        int bytesRead;
                        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                        }
                        output.Close();
                    }
                }
        //logging good news and info
        MyLogManager("Good news", FileDetails);
    }
    catch(Exception ex)
    {
        //logging bad news and exceptions info
        MyLogManager("Bad news", ExceptionDetails);
    }
