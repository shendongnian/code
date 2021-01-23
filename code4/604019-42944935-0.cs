    public bool EqualList(Dictionary<int, string> a, Dictionary<int, string> b)
            {
                if (a.Count == b.Count)
                {
                    bool rs = false;
                    foreach (var i in a)
                    {
                        if (b.ContainsKey(i.Key))
                        {
                            rs = true;
                        }
                        else
                        {
                            rs = false;
                            break;
                        }
                    }
                    return rs;
                }
                else
                {
                    return false;
                }
