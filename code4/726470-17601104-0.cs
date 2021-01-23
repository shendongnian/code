    public class WrongEmployeeIDException : Exception
            {
                public WrongEmployeeIDException(string message) : base(message) { }
            }
     public class Employee
            {
                private int employerId;
                public int EmployerId
                {
                    get { return employerId; }
                    set
                    {
                        if (value < 5 || value > 10)
                        {
                            throw new WrongEmployeeIDException("Invalid id");
                        }
    
                        employerId = value;
                    }
                }
            }
    
            
            public void Main()
            {
                int id;
                string input;
                bool isSetted = false;
                Employee employee = new Employee();
                while (!isSetted)
                {
                    Console.Write("Enter employer ID: ");
                    try
                    {
                        input = Console.ReadLine();
                        id = Convert.ToInt32(input);
                        employee.EmployerId = id;
                        isSetted = true;
                    }
                    catch (WrongEmployeeIDException ex)
                    {
                        Console.WriteLine(ex.Message);
                        //not satisfied to bussiness rules
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        //Convert.ToInt32 thrown exception
                    }
                    catch
                    {
                        //something more bad happend
                    }
                }
            }
