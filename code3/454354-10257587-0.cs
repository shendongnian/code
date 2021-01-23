    class Program
    {
        static void Main(string[] args)
        {
            Container c = new Container();
            c.CreateEventForKey("a");             // Create the member in the dictionary
            c.EventForKey("a").Add(str => Console.WriteLine(str));
            c.EventForKey("a").Add(str => Console.WriteLine(str.ToUpper()));
            c.OnEventForKey("a", "baa baa black sheep");
    
            Console.ReadLine();
            }
        }
        
        public class Container
        {
        
            public class Member
            {
            public List<Action<string>> AnEvent = new List<Action<string>>();
            public void OnEvent(string v)
            {
                if (AnEvent != null)
                {
                    this.AnEvent.ForEach(action => action(v));
                }
            }
    
            public void AddEvent(Action<string> action)
            {
                this.AnEvent.Add(action);
            }
        }
    
        protected Dictionary<string, Member> members = new Dictionary<string,Member>();
    
        public void CreateEventForKey(string key)
        {
            this.members[key] = new Member();
        }
    
        // This seems to work OK.
        public void OnEventForKey(string k, string v)
        {
            if (members.ContainsKey(k)) { members[k].OnEvent(v); }
            else { /* report error */ }
        }
    
        public List<Action<string>> EventForKey(string k)
        {
            if (members.ContainsKey(k)) { return members[k].AnEvent; }
            else { throw new KeyNotFoundException(); }
        }
    }
