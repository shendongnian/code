        public static void Main(string[] args)
        {
            RestartApplication:
            //// Displays data in correct Format
            TextReader textReader = new StreamReader("c:/users/tom/documents/visual studio 2010/Projects/DistanceCalculator3/DistanceCalculator3/TextFile1.txt");
            var input = Convert.ToString(textReader.ReadToEnd());
            var items = input.Split(',');
            Console.WriteLine("Point         Latitude        Longtitude       Elevation");
            for (var i = 0; i < items.Length; i++)
            {
                if (i % 3 == 0)
                {
                    Console.Write((i / 3) + "\t\t");
                }
                Console.Write(items[i]);
                Console.Write("\t\t");
                if (((i - 2) % 3) == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            //// Ask for two inputs from the user which is then converted into 6 floats and transferred in class Coordinates    
            Console.WriteLine("Please enter the two points that you wish to know the distance between:");
            var point = Console.ReadLine();
            string[] pointInput;
            if (point != null)
            {
                pointInput = point.Split(' ');
            }
            else
            {
                goto RestartApplication;
            }
            var pointNumber = Convert.ToInt16(pointInput[0]);
            var pointNumber2 = Convert.ToInt16(pointInput[1]);
            var distance = new Coordinates
                {
                    Latitude = Convert.ToDouble(items[pointNumber * 3]),
                    Longtitude = Convert.ToDouble(items[(pointNumber * 3) + 1]),
                    Elevation = Convert.ToDouble(items[(pointNumber * 3) + 2]),
                    Latitude2 = Convert.ToDouble(items[pointNumber2 * 3]),
                    Longtitude2 = Convert.ToDouble(items[(pointNumber2 * 3) + 1]),
                    Elevation2 = Convert.ToDouble(items[(pointNumber2 * 3) + 2])
                };
            //// Calculate the distance between two points
            const double PIx = 3.141592653589793;
            const double Radio = 6371;
            var dlat = (distance.Latitude2 * (PIx / 180)) - (distance.Latitude * (PIx / 180));
            var dlon = (distance.Longtitude2 * (PIx / 180)) - (distance.Longtitude * (PIx / 180));
            var a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(distance.Latitude * (PIx / 180)) * Math.Cos(distance.Latitude2 * (PIx / 180)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            var angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var ultimateDistance = angle * Radio;
            Console.WriteLine("The distance between your two points is...");
            Console.WriteLine(ultimateDistance);
            //// Repeat the program if the user enters 1, end the program if the user enters -1
            Console.WriteLine("If you wish to calculate another distance type 1 and return, if you wish to end the program, type -1.");
            var userInput = Console.ReadLine();
            if (Convert.ToInt16(userInput) == 1)
            {
                //// Here is where the application will repeat.
                goto RestartApplication;
            }
        }
