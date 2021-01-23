    public IEnumerable<Car> LoadCarDetails(IList<int> carIds)
    {
       var cars = Uow.Query<Car>().Where(x => carIds.Contains(x.Id));
       return cars;
    }
    public StringWriter ConvertCarListToStrings(IEnumerable<Car> cars)
    {
       var stringWriter = new StringWriter();
    
       stringWriter.WriteLine("Make, Model, Year");
    
       foreach(var car in cars)
       {
         stringWriter.WriteLine("{0},{1},{2}", car.Make, car.Model, car.Year);
       }
    
       return stringWriter;
    }
    
    public void SaveToFile(StringWriter stringWriter, string location)
    {
       var bytes = new System.Text.UTF8Encoding().GetBytes(stringWriter.ToString());
       var file = System.IO.File.OpenWrite(location);
       file.Write(bytes, 0, bytes.Length);
       file.Close();
    }
