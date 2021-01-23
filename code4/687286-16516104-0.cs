        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 50000; i++)
            {
                HasStaticObjects hso1 = new HasStaticObjects();
                ClearAllStaticValues(hso1);
            }
            Console.WriteLine("Clear Generic Static Values: \n" + sw.Elapsed);
            sw.Restart();
            for (int i = 0; i < 50000; i++)
            {
                HasStaticObjects hso2 = new HasStaticObjects();
                hso2.ClearStaticValues();
            }
            Console.WriteLine("Clear Static Values: \n" + sw.Elapsed);
            Console.ReadLine();
        }
        public static void ClearAllStaticValues<T>(T currentClass)
        {
            var varList = currentClass.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Static).ToList();
            varList.Where(x => x.FieldType == typeof(Int32)).ToList().ForEach(x => x.SetValue(null, 0));
            varList.Where(x => x.FieldType == typeof(string)).ToList().ForEach(x => x.SetValue(null, ""));
        }
    }
    class HasStaticObjects
    {
        private static int A, B, C;
        private static string D, E, F;
        public HasStaticObjects()
        {
            A = 1;
            B = 2;
            C = 3;
            D = "Hi";
            E = "Good";
            F = "Fast";
        }
        public void ClearStaticValues()
        {
            A = 0;
            B = 0;
            C = 0;
            D = "";
            E = "";
            F = "";
        }
