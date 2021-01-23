    class C {
        private Action<string> action = delegate {};
        public void OneMethod(string s) { 
            action(s);
        }
    
        public void ChangeMethods() {
            action = delegate(string s) { };
        }
    }
