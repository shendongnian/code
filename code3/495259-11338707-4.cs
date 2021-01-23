            public List<float> GetListFloatKey(string keybase)
            {
                List<float> ret = new List<float>();
                foreach (string key in this.Keys.Keys)
                {
                    if (Regex.IsMatch(key, keybase + "[0-9]+"))
                        ret.Add(float.Parse(this.Keys[key]));
                }
                return ret;
            }
            public void SetListFloatKey(string keybase, List<float> values)
            {
                List<string> oldkeys = new List<string>();
                foreach (string key in this.Keys.Keys)
                {
                    if (Regex.IsMatch(key, keybase + "[0-9]+"))
                        oldkeys.Add(key);
                }
                foreach (string key in oldkeys)
                    this.Keys.Remove(key);
                for (int i = 0; i < values.Count; i++)
                    this.Keys.Add(keybase + i.ToString(), values[i].ToString());
            }
