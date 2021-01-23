      struct information {
        public string name;
        public scores[] scoreList;
    
        // Constructor
        public information(String nameValue) {
          name = nameValue;
          scoreList = new scores[10]; // <- It's possible here
        }
      };
