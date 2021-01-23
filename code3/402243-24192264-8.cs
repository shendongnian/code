    class Person2 {
        private String fName;
        public Person2(string fName) {
            setFname(fName);
        }
        private void setFname(String fName) {
            this.fName = fName.ToLower();
        }
        public String getFname() {
            return this.fName+ ".addedText";
        }
    }
