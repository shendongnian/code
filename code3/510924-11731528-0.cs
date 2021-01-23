    private void button1_Click(object sender, EventArgs e)
    {
        string tempString = "";
        string startString = "start string";
        string endString = "end string";
        bool startFlag = false;
        bool endFlag = true;
        string filename = @"C:\file.txt";
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
        {
            WebRequest request = WebRequest.Create("http://www.website.com/webpage.html");
            request.Credentials = CredentialCache.DefaultCredentials;
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                Console.WriteLine(response.StatusDescription);
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        while (endFlag)
                        {
                            tempString = reader.ReadLine();
                            if (tempString.Contains(startString))
                            {
                                startFlag = true;
                            }
                            if (tempString.Contains("text"))
                            {
                                // ...
                            }
                            if (tempString.Contains("other text"))
                            {
                                if (startFlag)
                                    file.WriteLine(tempString.Trim());
                            }
                            if (tempString.Contains("different text"))
                            {
                                if (startFlag && tempString.Length > 0)
                                    file.WriteLine(tempString.Trim());
                            }
                            if (tempString.Contains(endString))
                            {
                                endFlag = false;
                            }
                        }
                        MessageBox.Show("Done!", "Finished Writing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        reader.Close();
                    }
                    dataStream.Close();
                }
                response.Close();
            }
        }
        Process.Start(filename);
        this.Close();
    }
