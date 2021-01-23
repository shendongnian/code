    public class MyFunctions
    {
        private static string _name;
        private static int _id;
        private static int _age;
        private static string _email;
        public static void WriteFunction()
        {
            int count = 0;
            while (count < 10)
            {
                Console.Write(" Enter your Name: ");
                _name = Console.ReadLine();
                Console.Write(" Enter your ID: ");
                _id = int.Parse(Console.ReadLine());
                Console.Write(" Enter your Age: ");
                _age = int.Parse(Console.ReadLine());
                Console.Write(" Enter your E-mail: ");
                _email = Console.ReadLine();
                count++;
            }
        }
        public static void ReadFunction()
        {
            string output =
                string.Format(
                    "Thank you for registration! Your Submitted information are:" + Environment.NewLine +
                    "Name: {0}"
                    + Environment.NewLine + "ID: {1}" + Environment.NewLine + "Age: {2}" + Environment.NewLine +
                    "E-mail: {3}", _name, _id, _age, _email);
            // I using the Environment.NewLine to insert new lines
            Console.WriteLine(output);
        }
    }
