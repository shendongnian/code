            StreamReader reader = new StreamReader("c:/yourFile.txt");
            Dictionary<string, string> yourDic = new Dictionary<string, string>();
            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(':');
                if (line != String.Empty)
                {
                    for (int i = 0; i < data.Length - 1; i++)
                    {
                        if (i != 0)
                        {
                            bool isPair;
                            if (i % 2 == 0)
                            {
                                isPair = true;
                            }
                            else
                            {
                                isPair = false;
                            }
                            if (isPair)
                            {
                                string keyOdd = data[i].Trim();
                                try { keyOdd = keyOdd.Substring(keyOdd.IndexOf(' ')).TrimStart(); }
                                catch { }
                                string valueOdd = data[i + 1].TrimStart();
                                try { valueOdd = valueOdd.Remove(valueOdd.IndexOf(' ')); } catch{}
                                yourDic.Add(keyOdd, valueOdd);
                            }
                            else
                            {
                                string keyPair = data[i].TrimStart();
                                keyPair = keyPair.Substring(keyPair.IndexOf(' ')).Trim();
                                string valuePair = data[i + 1].TrimStart();
                                try { valuePair = valuePair.Remove(valuePair.IndexOf(' ')); } catch { }
                                yourDic.Add(keyPair, valuePair);
                            }
                        }
                        else
                        {
                            string key = data[i].Trim();
                            string value = data[i + 1].TrimStart();
                            try { value = value.Remove(value.IndexOf(' ')); } catch{}
                            yourDic.Add(key, value);
                        }
                    }
                }
            }
