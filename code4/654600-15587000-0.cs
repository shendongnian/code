        static void A(string s)
        {
            //Code Here...
        }
        static void B(string s)
        {
            //Code Here...
        }
        static void C(string s)
        {
            //Code Here...
        }
        public struct ActionStruct {
          public string String;
          public Action<string> Action;
          public ActionStruct(string s, Action<string> a) : this() {
            String = s; Action = a;
          }
        }
        void Main(string[] args) {
          var actions = new List<ActionStruct>() {
            new ActionStruct("A", s => A(s)),
            new ActionStruct("B", s => B(s)),
            new ActionStruct("C", s => C(s))
          };
          var action = actions.Where(a=>a.String == args[0]).FirstOrDefault();
          if (action.String!= "") action.Action(args[1]);
        }
