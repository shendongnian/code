                System.Diagnostics.Debug.Write("----- CLIENT HEADERS -----" + Environment.NewLine);
                foreach (KeyValuePair<string, IEnumerable<string>> myHeader in myHttpClient.DefaultRequestHeaders)
                {
                    System.Diagnostics.Debug.Write(myHeader.Key + Environment.NewLine);
                    foreach(string myValue in myHeader.Value)
                    {
                        System.Diagnostics.Debug.Write("\t" + myValue + Environment.NewLine);
                    }
                }
                System.Diagnostics.Debug.Write("----- MESSAGE HEADERS -----" + Environment.NewLine);
                foreach (KeyValuePair<string, IEnumerable<string>> myHeader in myHttpRequestMessage.Headers)
                {
                    System.Diagnostics.Debug.Write(myHeader.Key + Environment.NewLine);
                    foreach (string myValue in myHeader.Value)
                    {
                        System.Diagnostics.Debug.Write("\t" + myValue + Environment.NewLine);
                    }
                }
                System.Diagnostics.Debug.Write("----- CONTENT HEADERS -----" + Environment.NewLine);
                foreach (KeyValuePair<string, IEnumerable<string>> myHeader in myHttpRequestMessage.Content.Headers)
                {
                    System.Diagnostics.Debug.Write(myHeader.Key + Environment.NewLine);
                    foreach (string myValue in myHeader.Value)
                    {
                        System.Diagnostics.Debug.Write("\t" + myValue + Environment.NewLine);
                    }
                }
