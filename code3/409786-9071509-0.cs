    class A 
    { 
        private B; 
        public void b(){ }
        public void c(){ B = b( );}
    } 
    
    class Program 
    {
        public static void Main ( string [ ] args ) 
        {
            A a = new A();
            a.c(); 
        }
    }
