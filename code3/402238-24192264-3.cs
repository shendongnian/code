    class Person {
        private String _fName;
        public String fName {
            get { return _fName + ".addedText"; }
            private set { _fName = value.ToLower(); }
        }
        public Person(String fName) {
            this.fName = fName;
        }
    }
