        class Program
        {
          static void Main(string[] args)
            {
            Program pg = new Program();
            Console.WriteLine("*****************************Program to Find 2nd Highest and 2nd lowest from set of values.**************************");
            Console.WriteLine("Please enter the comma seperated numbers : ");
            string[] val = Console.ReadLine().Split(',');
            int[] inval = Array.ConvertAll(val, int.Parse); // Converts Array from one type to other in single line  or Following line
            // val.Select(int.Parse)
            Array.Sort(inval);
            Console.WriteLine("2nd Highest is : {0} \n 2nd Lowest is : {1}", pg.Return2ndHighest(inval), pg.Return2ndLowest(inval));
            Console.ReadLine();
            
            }
            //Method to get the 2nd lowest and 2nd highest from list of integers ex 1000,20,-10,40,100,200,400
            public  int Return2ndHighest(int[] values)
            {
               if (values.Length >= 2)
                  return values[values.Length - 2];
               else
                  return values[0];
             }
             public  int Return2ndLowest(int[] values)
             {
                  if (values.Length > 2)
                      return values[1];
                  else
                      return values[0];
              }
         }
