    namespace CE0721a
    {
        class Tut4_7
        {
            public void run()
              {
                double under16_Free = 2.5;
                double oap = 3.0;
                double other = 5.0;
                int groupSize = 0;
                double totalCost = 0;
                int age = 0;
    
            while (age!=-1)
            {
                Console.WriteLine("Enter an Age or -1 to quit");
                age=int.Parse(Console.ReadLine());
    
                if(age<16 && age>-1)
                {
                    groupSize++;
                    totalCost = totalCost + under16_Free;
                }
                else if(age>16)
                {
                    groupSize++;
                    totalCost = totalCost + oap;
                }
                else if(age>16 && age<=65)
                {
                    groupSize++;
                    totalCost = totalCost + other;
                }
            }
            if (groupSize>6)
            {
                totalCost = totalCost - (totalCost/5);
            }
            Console.WriteLine("Total Cost = "(totalCost));
            }
        }
    }
