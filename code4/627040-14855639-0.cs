    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "STRUCT[1].VARSTRUCT[10].VAR[1]";
            string str2 = "STRUCT[%].VARSTRUCT[%].VAR[%]";
            string str3 = "STRUCT[%].VARSTRUCT[%].VAR[2]";
            Console.WriteLine("str1 - str2: " + SpecialComparers.AreEqual(str1, str2));
            Console.WriteLine("str2 - str3: " + SpecialComparers.AreEqual(str2, str3));
            Console.WriteLine("str1 - str3: " + SpecialComparers.AreEqual(str1, str3));
        }
    }
    class SpecialComparers
    {
        public static bool AreEqual(String in1, String in2)
        {
            Regex re = new Regex(@"STRUCT\[(\d+|%)\]\.VARSTRUCT\[(\d+|%)\]\.VAR\[(\d+|%)\]");
            var values1 = re.Match(in1).Groups;
            var values2 = re.Match(in2).Groups;
            if (values1.Count != values2.Count) return false;
            for (int i = 1; i <= values1.Count; i++ )
            {
                if (!values1[i].ToString().Equals(values2[i].ToString())
                    && !values1[i].ToString().Equals("%")
                    && !values2[i].ToString().Equals("%")
                )
                    return false;
            }
            return true;
        }
    }
