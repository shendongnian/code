    public static List<Employee> ReadFromFile(string path = "1.txt") 
    {
        List<Employee> employees = new List<Employee>();
        Stream stream = null;
        StreamReader sr = null;
        try
        {
            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            stream.Seek(0, SeekOrigin.Begin);
            sr = new StreamReader(stream);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Employee employee = new DynamicEmployee();
                // string str = sr.ReadLine(); // WRONG, reading 2x
                employee.FirstName = line.Substring(1, 20).Trim();
                employee.LasttName = line.Substring(20, 20).Trim();
                employee.Paynment = Convert.ToDouble(line.Substring(40, 20).Trim());
                Console.WriteLine("{0} {1} {2}", employee.FirstName, employee.LasttName, employee.Paynment);
                employees.Add(employee);
                //Console.WriteLine(str);
            }
        }
        catch//(System.FormatException)
        {
            Console.WriteLine("File format is incorect");
        }
        finally
        {
            sr.Close();
            stream.Close();
        }
        return employees;
    }
