    static void Main(string[] args)
            {
                var input = "fsyfugiuhknklmoiuiuutyughvhjbiuhi jhiubuguygfvtdrcrsresetgfcyuhijoj".ToCharArray();
                var elementsToConsider = 3;
                StringBuilder sb = new StringBuilder();
    
                for (int i = 0; i < input.Length; i++)
                {
                    sb.AppendLine(input.Skip(i).Take(elementsToConsider).Aggregate("",(a, b) => a + b));
                    i = i + (elementsToConsider  -1);
                }
                Console.WriteLine(sb.ToString());
                Console.ReadKey();
            }
