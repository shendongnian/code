    private int WordCount(string awsBucketName, string awsFilePath, string wordForSearch)
        {
            string line =string.Empty;
            int counter = 0;
            if ((cloudKaseClient != null) & (token == tokenCfg))
            {
                var request = new GetObjectRequest()
                {
                    BucketName = awsBucketName,
                    Key = awsFilePath
                };
                 using (var response = cloudKaseClient.GetObject(request))
                {
                        StreamReader reader = new StreamReader(response.ResponseStream);
                        while ((line = reader.ReadLine()) != null)
                        {
                            counter += line.Split(' ').Where(t => t.ToString().ToLower().Contains(wordForSearch.ToLower())).Count();
                        }
                        reader.Close();             
                }
            }
            return counter;
        }
