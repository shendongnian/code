    using System;
    using System.Diagnostics;
    using System.Globalization;
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            DateTime date = DateTime.Now;
            foreach (CultureInfo culture in cultures)
            {
                string tmp = date.ToString("d", culture).Replace(date.ToString("yyyy", culture), string.Empty);
                char last = tmp[tmp.Length - 1];
                char[] trimmer = char.IsDigit(last) ? new char[] { tmp[0] } : new char[] { last };
                string dateStr = tmp.Trim(trimmer);
                Console.WriteLine(string.Format("{0,12}, {1,15} => {2,10}", culture.IetfLanguageTag, date.ToString("d", culture), dateStr));
            }
            if (Debugger.IsAttached)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to exit..");
                Console.ReadKey();
            }
        }
    }
