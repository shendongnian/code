        private int myVar;
        public int MyProperty
        {
            get 
            { 
                return myVar; 
            }
            set 
            {
                myVar = value; 
            }
        }
        public void SetMyPropertySpecial(int a, string reason)
        {
            Console.WriteLine("MyProperty was changed because of " + reason);
            this.myVar = a;
        }
