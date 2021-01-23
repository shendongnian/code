            public static List<List<string>> ListToSublists(List<string> lsSource)
            {
                List<List<string>> lsTarget = new List<List<string>>();
    
                List<string> ls = null;
                for (int i = 0; i < lsSource.Count; ++i)
                {
                    if (i % 100 == 0)
                    {
                        if(ls != null)
                            lsTarget.Add(ls);
                        ls = new List<string>();
                    }
                    ls.Add(lsSource[i]);
                }
    
                return lsTarget;
            }
        public static void main()
        {
            var yourlist = new List<string>();
            yourlist.AddRange( /* Whatever */ ); 
            List<List<string>> ls = ListToSublists(yourlist );
            foreach (List<string> result in ls)
            {
                if (result.Count > 0)
                {
                    // divide it into groups with length of 100 and then for each group do
                    // the following method.
                    handler.send(result.ToArray(), smscontext);
                }
            }
        }
