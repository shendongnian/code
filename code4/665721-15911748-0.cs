       for (int x = 0; x < taxarray.Length; x++)
       {
            taxarray[x] = new Taxpayer();
            Console.Write("Enter Social Security Number for taxpayer {0}: ", x+1);
            taxarray[x].SSN = Console.ReadLine();
            Console.Write("Enter gross income for taxpayer {0}: ", x+1);
            taxarray[x].grossIncome = Convert.ToDouble(Console.ReadLine());
            Taxpayer.getRates();
       }
