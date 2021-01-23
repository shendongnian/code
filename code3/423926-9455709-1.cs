        try
        {
            using (var myHttpWebResponse = (HttpWebResponse) httPrequestCreated.GetResponse())
            {
                var streamResponse = myHttpWebResponse.GetResponseStream();
                if (streamResponse != null)
                {
                    var streamRead = new StreamReader(streamResponse);
                    var readBuff = new Char[256];
                    var count = streamRead.Read(readBuff, 0, 256);         
                    while (count > 0)
                    {
                        var outputData = new String(readBuff, 0, count);
                        finalResopnse += outputData;
                        count = streamRead.Read(readBuff, 0, 256);
                    }
                    streamRead.Close();
                    streamResponse.Close();
                    myHttpWebResponse.Close();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.format("this went wrong: {0}", ex.Message));
        }
