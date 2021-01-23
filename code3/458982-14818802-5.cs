            List<string> lst = new List<string>();
            lst.AddRange(new string[] {"A", "B", "C" });
            SubSet<string> subs = new SubSet<string>(lst);
            IList<string> l = subs.Next();
            while (l != null)
            {
                DoSomething(l);
                l = subs.Next();
            }
