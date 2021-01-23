    using (var reader = new CsvReader(new StreamReader(@"C:\Users\afshandc\Desktop\0729\vTest.csv"), config))
         {
            while (reader.Read())
            {
               string line = reader.GetField(1);
               string[] classParams = line.Split(',');
               Vehicle v = new Vehicle()
              {
               ID = int.Parse(classParams[0]),
               ClosingDate = classParams[1],
               Model = classParams[2],
               Reg = classParams[3],
               YearOfManufacture = classParams[4],
               VehicleType = classParams[5],
               Fuel = classParams[6],
               Brand = classParams[7],
               Mileage = classParams[8],
               Make = classParams[9],
               Colour = classParams[10],
               VehicleYard = classParams[11],
               BasicOptions = classParams[12],
               Description = classParams[13],
               Photos = GetJoinedByPlus(classParams[14]),
               Regions = GetJoinedByPlus(classParams[15])
              };
            }
         }
      private List<string> GetJoinedByPlus(string p)
      {
         List<string> rtVal = new List<string>();
         rtVal.AddRange(p.Split('+'));
         return rtVal;
      }
