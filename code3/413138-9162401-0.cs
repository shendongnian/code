      List<Cars> cars = new List<Cars>();
      int totalCars;
      protected void Page_Load(object sender, EventArgs e)
      {
          cars = new List<Cars>();
          for(int i=0; i<totalCars; i++)
          {  
               cars.Add(
                  new Cars()
                    {
                      Name = "Car #" + i;
                      ID = i;
                    }
                  );
          }          
      }
