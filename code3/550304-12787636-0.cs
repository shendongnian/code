    public static void Main(string[] args)
        {
            string inValue;
            int noNames;
            string[] names = new string[100];
           // find number of names
            Console.WriteLine("Enter the number of names: ");
            inValue = Console.ReadLine();
            int.TryParse(inValue, out noNames);
            string[] fullName = new string[noNames];
            for (int i = 0; i < fullName.Length; i++)
            {
                string[] name = fullName[i].Split(' '); //error appears here
            }
        }
