    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Data data = new Data();
    
                //Gets all fields
                FieldInfo[] fields = typeof(Data).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    
                foreach (var field in fields)
                {
                    //Might want to put some logic here to determin a type of the field eg: (int, double) 
                    //etc and based on that set a value
    
                    //Resets the value of the field;
                    field.SetValue(data, 0);
                }
    
                Console.ReadLine();
            }
    
            public class Data
            {
                private Double jtime, jendtime, jebegintime, javerage = 10;
            }
        }
    }
