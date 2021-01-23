    class Company
    {
      private string name;
      private int id; 
      private string city;
      private String state;
      
      public string Name { get { return name; } }
      public int Id  { get { return id; } } 
      public string City { get { return city; } }
      public String State { get { return state; } }
    
      public Company() { }
    
      public override string ToString() 
      {
        // Here you create a formatted string from the fields, e.g.:
        return name + " " + id + " " + city + " " + state;
      }
    
      public static Company FromLine(string line)
      {
        // Here you do the parsing and formatting of a line, e.g.:
        string[] tokens = line.Split(separators);
        name = tokens[0];
        id = Convert.ToInt32(tokens[1]);
        city = tokens[2];
        state = tokens[3];
      }
    }
