    class Check
    {
        private Some getsome;
    
        public Some GetSome
        {
           get
           {
                return getsome;
           }
           set
           {
               if(value != null)
                  getsome = value;//or any other logic you want
           }
        }
    
        public Check()
        {
          
        }
    
    }
