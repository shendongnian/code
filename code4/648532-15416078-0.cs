    static int SumVals(params int[] vals)//parameter array
        {
            int sum = 0;
            foreach (int val in vals) //for each interger value 
            {
                if(val < 10) //only add to the sum if value is less than 10
                     sum += val; //sum equals sum plus val. returns all values added together
            }
            return sum;
        }
    
        static void Main(string[] args)
        {
            int sum = SumVals(100, 5, 2, 9, 800);
            Console.WriteLine("Summed Values = {0}", sum);
            Console.ReadKey();
        }
