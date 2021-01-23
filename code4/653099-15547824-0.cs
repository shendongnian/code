    class Person 
    {
        public string Firstname {get; set;}
        public string Lastname {get; set;} 
     
        public override bool Equals(object other) 
        {
          var toCompareWith = other as Person;
          if (toCompareWith == null) 
            return false;
          return this.Firstname ==  toCompareWith.Firstname && 
              this.Lastname ==  toCompareWith.Lastname; 
        }
    }  
