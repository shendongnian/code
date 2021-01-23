    class Checks {
    
        // this string, declared in the class body but outside
        // methods, is a class variable, and can be accessed by
        // any class method. 
        string _hostname2;
        public Checks(string hostname2) {
            _hostname2 = hostname2;
        }
        public void Testing() {
            MessageBox.Show(_hostname2);
        }
    }
