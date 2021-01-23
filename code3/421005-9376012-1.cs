    class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
                Console.WriteLine(p.GetFullName());
                Console.ReadLine();   
            }
    
            string GetFullName()
            {
                string result =GetFirstName() + " " + GetLastName();
                return result;
            }
    
            string GetFirstName()
            {
                string firstname = "vishwanath";
                return firstname;
            }
    
            string GetLastName()
            {
                string lastname = "Dalvi";
                return lastname;
            }
        }
