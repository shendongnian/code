    using System;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime dob = new DateTime(2010, 12, 30);
                DateTime today = DateTime.Now;
                int age = AgeInYears(dob, today);
                Console.WriteLine(age); // Prints "1"
            }
            static int AgeInYears(DateTime birthday, DateTime today)
            {
                return ((today.Year - birthday.Year) * 372 + (today.Month - birthday.Month) * 31 + (today.Day - birthday.Day)) / 372;
            }
        }
    }
