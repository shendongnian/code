        case 1:
            double[] myArrai1 = new double[3];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("*-------------------------------------------------------* ");
            Console.WriteLine("*  Enter an array of numbers to get the sum total       * ");
            Console.WriteLine("*-------------------------------------------------------* ");
            Console.WriteLine("Insert a number");
            myArrai1[0] = double.Parse(Console.ReadLine());
            Console.WriteLine("Insert a number");
            myArrai1[1] = double.Parse(Console.ReadLine());
            Console.WriteLine("Insert a number");
            myArrai1[2] = double.Parse(Console.ReadLine());
            DrawStarLine();
            foreach (double d in myArrai1)
            Console.WriteLine( d );
            Webservices09004961.ServiceReference1.Service1SoapClient client2 = new ServiceReference1.Service1SoapClient();
            Webservices09004961.ServiceReference1.ArrayOfDouble arrayOfDoubles = new Webservices09004961.ServiceReference1.ArrayOfDouble(); 
            arrayOfDoubles.AddRange(myArrai1);
            string e = client2.CalculateSum(arrayOfDoubles);
            Console.WriteLine("=" + e);
            Console.ReadLine();
            break;
