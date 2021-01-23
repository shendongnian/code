    using System;
    using System.Collections;
    using System.IO;
    using System.Globalization;
    using System.Text;
    class FunWithScheduling
    {
         public void AddView()
         {
            FileStream s = new FileStream("Scheduler.txt",FileMode.Append,FileAccess.Write);
            StreamWriter w = new StreamWriter(s);
            var builder = new StringBuilder();
            Console.WriteLine("Enter the Name of the Person To Be Met:");
            string Name = Console.ReadLine();
            builder.Append(Name);
            Console.WriteLine("Enter the Date Scheduled For the Meeting:");
            string Date = Console.ReadLine();
            DateTime date;
            if(!DateTime.TryParseExact(Date,"MM-dd-yyyy",new CultureInfo("en-US"),DateTimeStyles.None,out date))
            {
                   Console.WriteLine("Invalid Choice");
            } else {
                builder.Append(date.ToString("MMMM dd, yyyy"));
            }
            Console.WriteLine("Enter the Time Scheduled For the Meeting:");
            string Time = Console.ReadLine();
            builder.Append(Time);
            w.WriteLine(builder.ToString());
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
