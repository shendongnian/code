    public class Line
    {
       public string A {get;set;}
       public More_B B {get;set;}
       public string C {get;set;}         
    }
    
    public class Information
    {
       public string Name { get; set;}
       public string Type { get; set;}
       public string Further_Info { get; set;}
    }
    public class More_B:Information
    {
       public string CusotmField {get;set;}
    }
    var B_Object = new More_B (Name = "The B", Type = "Some type", Further_Info = "More Info");
    IList<More_B> B_List=new List<More_B>();
    var searchObj = B_List.Where(x => x.Name=="The B").FirstOrDefault();
