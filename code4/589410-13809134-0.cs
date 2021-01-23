    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace ReadStudents
    {
        class Program
        {
            static string _filename = "students.txt";
    
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>();
                
                // Load students.
                StreamReader reader = new StreamReader(_filename);
                while (!reader.EndOfStream)
                    students.Add( new Student( reader.ReadLine()));
                reader.Close();
                
                string action; 
                bool showAgain = true;
    
                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("1. See all students.");
                    Console.WriteLine("2. See student by ID.");
                    Console.WriteLine("3. Add new student.");
                    Console.WriteLine("0. Exit.");
                    Console.WriteLine("");
    
                    action = Console.ReadLine();
    
                    switch (action)
                    {
                        case "1":
                            foreach (Student item in students)
                                item.Show();
                            break;
    
                        case "2":
                            Console.Write("ID = ");
                            int id = int.Parse( Console.ReadLine() ); // TODO: is valid int?
    
                            foreach (Student item in students)
                                if (item.Id == id)
                                    item.Show();
                            break;
    
                        case "3":
                            Console.WriteLine("ID-Name");
    
                            Student newStudent = new Student(Console.ReadLine());
                            students.Add(newStudent);
    
                            StreamWriter writer = new StreamWriter(_filename, true);
                            writer.WriteLine(newStudent);
                            writer.Close();
    
                            break;
    
                        case "0":
                            Console.WriteLine("Bye!");
                            showAgain = false;
    
                            break;
    
                        default:
                            Console.WriteLine("Wrong action!");
                            break;
                                    
                    }
                }
                while (showAgain);
            }
        }
    
        class Student
        {
            public int Id;
            public string Name;
    
            public Student(string line)
            {
                string[] fields = line.Split('-');
    
                Id = int.Parse(fields[0]);
                Name = fields[1];
            }
    
            public void Show()
            {
                Console.WriteLine(Id + ". " + Name);
            }
        }
    }
