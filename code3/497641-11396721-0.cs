    interface IDataReader
    {
       void Load(DataReader reader);
    }
    
    public class Employee : IDataReader
    {
       // some code... members...
    
       public void Load(DataReader reader)
       {
            /// some code...
       }
    }
    public static void Load(IDataReader reader, int id)
    {
       // lots of code...
       if (dr.Read())
       {        
            // the specific reader would create its own type within... 
            // there by keeping the instance creation with in the LoadDataReader.
            // ex: If reader's type is Employee it would create Employee and setup the object with info from the reader?
            reader.LoadDataReader(dr);
    
       }
    }
 
