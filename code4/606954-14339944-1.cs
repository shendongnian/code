    class Person
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public double Score { get; set; }
        public DataTable GetDataTable()
        {
          DataTable result = new DataTable();
          result.Columns.Add("ID", ID.GetType());
          result.Columns.Add("Name", Name.GetType());
          result.Columns.Add("Age", Age.GetType());
          result.Columns.Add("Score", ID.GetType());
          return result;
        } 
    }
    class Program {
      static void Main(string[] args)
      {
        var set = new DataSet("Test");
        var p1 = new Person() { ID = 1, Name = "P1", Age = 32, Score = 50.4 };
        set.Tables.Add(p1.GetDataTable());
        var schema = set.GetXmlSchema();
        Console.WriteLine(schema);
      }
    }
