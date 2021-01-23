    class SomeClass
    {
        public void SomeFunction()
        {				
            new List<string>().ForEach(e => this.MyAction(e));
       }
    
        private void MyAction(string str){ /* ... */ }
    }
