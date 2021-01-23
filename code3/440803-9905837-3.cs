            IEnumerable<Tuple<string, string, Action>> actions = new List<Tuple<string, string, Action>>() { 
            Tuple.Create<string, string, Action>("A", "1", SomeMethod1), 
            Tuple.Create<string, string, Action>("A", "2", SomeMethod2) 
            };
            string x = "A";
            string y = "2";
            var action = actions.FirstOrDefault(t => ((t.Item1 == x) && (t.Item2 == y)));
            if (action != null)
                action.Item3();
            else
                DoSomeDefaultMethod();
            public void SomeMethod1() { // Whatever you want to do  }
            public void SomeMethod2() { // Whatever you want to do  }
 
            public void DoSomeDefaultMethod() { // Default Method  } 
