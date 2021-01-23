    while (reader.Read())
            {
                switch (reader.Name)
                {
                    case "url":
                        try
                        {
                            reader.Read();
                            if (!reader.Value.Equals("\r\n"))
                            {
                                urlList.Add(reader.Value);
                            }
                        }
                        catch
                        {
                            invalidUrls.Add(urlList.Count);
                            continue;
                        }
                        break;
                }
            }
