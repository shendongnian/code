    class Bird : Animal {
        public static readonly dynamic Shared = new ExpandoObject();
    
    
    }
    Bird.Shared.Fly = new Action (()=>Console.Write("Yes I can"));
