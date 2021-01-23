    class ThirdClass : FirstClass
    { 
        // Must implement abstract methods
        public override void Edit() { }
        public override void New() { }
        public override void Delete() { }
 
        // Optionally override 
        public override void Exit() { /* custom implementation */  }
    }
