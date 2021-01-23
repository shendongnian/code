    class Singleton
    {
        //Variable
        private static Singleton Instance;
        private List<string> Messages;
        //Constructor
        private Singleton() 
        {
         Messages = new List<string>(); //Make sure to instantiate instance types before use. 
        }
        //Property
        public static Singleton GetInstance()
        {
                if (Instance == null)
                {
                    Instance = new Singleton();
                }
                return Instance;
          
        }
        //Methods
        public void Message(string message)
        {
            Messages.Add(message);
        }
        public bool HasMessage(string message)
        {
            return Messages.Contains(message);
        }
    }
