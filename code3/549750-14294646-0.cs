            int pounds;           
            int kilo;              
            Console.WriteLine("Please enter (1)lb. conversion(2) kg. conversion");
            int userNumber = int.Parse(Console.ReadLine());
            if (userNumber == 1)
            {
                Console.WriteLine("Please enter the weight(in kilograms) you would like to convert in pounds.");
                pounds = Int32.Parse(Console.ReadLine());
                Console.WriteLine("The weight in pounds is:{0:F3}", pounds / 2.2);
            }
            else
            {
                Console.WriteLine("Please enter the weight(in pounds) you would like to conver in kilograms");
                kilo = Int32.Parse(Console.ReadLine());
                Console.WriteLine("The weight in kilograms is:{0:F3}", kilo * .45);
            }
            Console.ReadLine();
