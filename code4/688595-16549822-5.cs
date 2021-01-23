    IDictionary<string, string> dict = new Dictionary<string, string>();
    
    public void copyFrom(NameValueCollection a)
    {
                foreach (var k in a.AllKeys)
                { 
                    dict.Add(k, a[k]);
                }  
    }
