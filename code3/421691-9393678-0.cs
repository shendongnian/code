        static void Main(string[] args)
        {
            const string text = "Casual Leave:12-Medical Leave :13-Annual Leave :03";
            foreach (var subStr in text.Split(":".ToCharArray()).Select(str => str.Trim()).SelectMany(trimmed => trimmed.Split("-".ToCharArray())))
                Console.WriteLine(subStr);
            Console.ReadLine();
        }
