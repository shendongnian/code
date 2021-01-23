            XmlTextReader reader = new XmlTextReader(fileName);
            var recordIndex = 0;
            while (reader.Read())
            {
                switch (reader.Name)
                {
                    case "url":
                        var url = reader.Value;
                        
                        if (!string.IsNullOrEmpty(url) && !url.Equals(Environment.NewLine))
                        {
                            urlList.Add(reader.Value);
                        }
                        else
                            invalidUrls.Add(recordIndex);
                        recordIndex ++;
                        break;
                }
            }
