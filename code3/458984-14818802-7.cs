            List<string> lst = new List<string>();
            lst.AddRange(new string[] {"A", "B", "C" });
            SubSet<string> subs = new SubSet<string>(lst);
            foreach(IList<string> l in subs)
            {
                DoSomething(l);
            }
