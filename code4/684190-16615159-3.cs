    public static void Main(string[] args)
        {
            var boos = new ChildWithBossValidation();
            var coolGuy = new ChildWithEasyGoingValidation();
            using (var ms = new MemoryStream())
            {
                var ser = new XmlSerializer(boos.GetType());
                ser.Serialize(ms, boos);
                string result = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                Console.WriteLine("With override");
                Console.WriteLine(result);
            }
            Console.WriteLine("-------------");
            using (var ms = new MemoryStream())
            {
                var ser = new XmlSerializer(coolGuy.GetType());
                ser.Serialize(ms, coolGuy);
                string result = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                Console.WriteLine("With override");
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }
