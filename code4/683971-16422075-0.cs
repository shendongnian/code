        public class Parent { }
        public class Child : Parent { }
        IList<Parent> parents = new List<Parent>()
        {
            new Parent()
        };
        foreach (Child child in parents) { }
