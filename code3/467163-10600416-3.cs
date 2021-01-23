     class A
      {
        private B b;
    
        public void Methode1()
        {            
            Methode2(b);
        }                
    
        private void Methode2(B b)
        {
            // use b.SomeProperty         
        }
      }
