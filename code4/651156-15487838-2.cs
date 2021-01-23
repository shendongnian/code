    class Datatable
    {
     public List<data> rows { get; set; }
     public Datatable(){
      rows = new List<data>();
     }
    }
    class data
    {
     public string Name { get; set; }
     public string Address { get; set; }
     public int Age { get; set; }
    }
    void Main()
    {
     var datatable = new Datatable();
     var r = new data();
     r.Name = "Jim";
     r.Address = "USA";
     r.Age = 23;
     datatable.rows.Add(r);
     List<string[]> MyStringArrays = new List<string[]>();
     foreach( var row in datatable.rows )//or similar
     {
      MyStringArrays.Add( new string[]{row.Name,row.Address,row.Age.ToString()} );
     }
     var s = MyStringArrays.ElementAt(0)[1];
     Console.Write(s);//"USA"
    }
