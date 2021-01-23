    public class TableCollection : List<Table>
    {
       private TableCollection() { }
    
       public static TableCollection FromFile(string filePath)
       {
           using (StreamReader reader = new StreamReader(filePath))
           {
               //populate all tables here before disposing
           }
       }
    }
    
    public class Table
    {
       //whatever other properties/methods
    
       //keep it internal to hide the implementation from the user
       internal Table(StreamReader reader)
       {
          //do what you need to do here
       }
    }
