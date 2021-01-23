    using System;
    using System.Collections;
    using System.IO;
    using System.Globalization;
    class FunWithScheduling
    {
         public void AddView()
         {
            Console.WriteLine("Enter the Name of the Person To Be Met:");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter the Date Scheduled For the Meeting:");
            string Date = Console.ReadLine();
            DateTime date;
            if(!DateTime.TryParseExact(Date,"MM-dd-yyyy",new CultureInfo("en-US"),DateTimeStyles.None,out date))
            {
                   Console.WriteLine("Invalid Choice");
                   return;
            }
            Console.WriteLine("Enter the Time Scheduled For the Meeting:");
            string Time = Console.ReadLine();
            string line = Name + "                                "+ Date +"             " + Time;
            FileStream s = new FileStream("Scheduler.txt",FileMode.Append,FileAccess.Write);
            StreamWriter w = new StreamWriter(s);
            w.WriteLine(line);
            w.Flush();
            w.Close();
            s.Close();
          }
          static void Main()
          {
            FunWithScheduling a = new FunWithScheduling();
            a.AddView();
          }
    } 
