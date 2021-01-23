    class Program
    {
        static string strFile = "Student Database.txt";
        static void Main(string[] args)
        {
            string strInput = ""; // user input string
            
            while (strInput != "3")
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo("student_results.txt");
                Console.WriteLine("\nWhat do you want to do?\n 1.View Student(s)\n 2.Add a New Student\n 3.Exit program"); // request user input as to actions to be carried out
                strInput = Console.ReadLine(); //save user input to make decision on program operation
                switch (strInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Enter Student ID: \n");
                        string file = AppDomain.CurrentDomain.BaseDirectory + @"student_results.txt";
                        StreamReader sr = new StreamReader(file);
                        string StudentID = Console.ReadLine();
                        string line = "";
                        bool found = false;
                        while((line = sr.ReadLine()) != null)
                        {
                            if (line.Split(',')[0] == StudentID)
                            {
                                found = true;
                                Console.WriteLine(line);
                                break;
                            }
                        }
                        sr.Close();
                        if (!found)
                        {
                            Console.WriteLine("Not Found");
                        }
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Enter Student ID : ");
                        string SID = Console.ReadLine();
                        Console.WriteLine("Enter Student Name : ");
                        string SName = Console.ReadLine();
                        Console.WriteLine("Enter Student Average : ");
                        string average = Console.ReadLine();
                        string wLine = SID + "," +SName+":"+average;
                        file = AppDomain.CurrentDomain.BaseDirectory + @"student_results.txt";
                        StreamWriter sw = File.Exists(file) ? File.AppendText(file) : new StreamWriter(file);
                        sw.WriteLine(wLine);
                        sw.Close();
                        Console.WriteLine("Student saved on file, press a key to continue ...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Command!\n");
                        break;
                }
            }
        }
    }
