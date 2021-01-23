            public List<float> GetListFloatKey(string keybase)
            {
                List<float> ret = new List<float>();
                foreach (string key in this.Pairs.Keys)
                {
                    if (Regex.IsMatch(key, keybase + "[0-9]+"))
                        ret.Add(float.Parse(this.Pairs[key].Value));
                }
                return ret;
            }
            public void SetListFloatKey(string keybase, List<float> values)
            {
                List<string> oldkeys = new List<string>();
                int startindex = -1;
                foreach (string key in this.Pairs.Keys)
                {
                    if (Regex.IsMatch(key, keybase + "[0-9]+"))
                    {
                        if (startindex == -1)
                            startindex = this.OrderedKeys.IndexOf(this.Pairs[key]);
                        oldkeys.Add(key);
                    }
                }
                foreach (string key in oldkeys)
                {
                    this.OrderedKeys.Remove(this.Pairs[key]);
                    this.Pairs.Remove(key);
                }
                for (int i = 0; i < values.Count; i++)
                {
                    KeyValuePair<string, string> pair = new KeyValuePair<string, string>(keybase + i.ToString(), values[i].ToString());
                    if (startindex != -1)
                        this.OrderedKeys.Insert(startindex + i, pair);
                    else
                        this.OrderedKeys.Add(pair);
                    this.Pairs.Add(pair.Key, pair);
                }
            }
