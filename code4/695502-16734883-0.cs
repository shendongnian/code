    public static DAL Instance
        {
            get
              {
                 if (instance == null) 
                 {
                     instance = new DAL();
                 }
                 return instance;
              }
         }
