    public class Employee
    {
        public int Employee_OID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"[{""Employee_OID"": 18450,""First_Name"": ""ABDUL"",""Last_Name"": ""RAJPUT""},{""Employee_OID"": 22446,""First_Name"": ""ABDUL"",""Last_Name"": ""KHAN""}]";
            List<Employee> emp = (new JavaScriptSerializer()).Deserialize<List<Employee>>(json);
            Console.WriteLine(emp.First().First_Name);
        }
    }
