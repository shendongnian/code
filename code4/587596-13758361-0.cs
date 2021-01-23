    List<Student> students = new List<Student>();
                Console.WriteLine("Enter name:");
                string nameInput = Console.ReadLine();
                // alternative is to generate own student number
                Console.WriteLine("Enter number:");
                string numberInput = Console.ReadLine();
                // perform validations then create Student                        
                int number;
                // check result of TryParse
                int.TryParse(numberInput, out number);            
                students.Add(new Student { Number = number, Name = nameInput });
