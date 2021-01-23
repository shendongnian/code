    using System;
    
    namespace ConsoleApplication2
    {
        public class UnitConverter
        {
            double ratio;
            public string From { get; set; }
            public string To { get; set; }
            public UnitConverter(double unitratio) { ratio = unitratio; }
            public double Convert(double unit) { return unit * ratio; }
        }
    
        class Test
        {
            private static void MakeConversion(UnitConverter customConverter)
            {
                Console.WriteLine("Enter a number of {0} to be converted to {1}.",customConverter.From, customConverter.To);
                double amount = Convert.ToDouble(Console.ReadLine());
                string message = string.Format("{0} {1} to said number of {2}", amount, customConverter.To, customConverter.From);
                Console.WriteLine(message);
            }
            
            public static void Main()
            {                 
                UnitConverter feetToInchesConverter = new UnitConverter(12) { From = "feet", To = "inches"};
                UnitConverter milesToFeetConverter = new UnitConverter(5280) { From = "miles" , To = "feet"};
                UnitConverter kmsToMilesConverter = new UnitConverter(1.609) { From = "kilometers", To = "miles"};
                UnitConverter centToInchesConverter = new UnitConverter(2.54) { From = "centimeters", To = "inches" };
                UnitConverter ozToGramsConverter = new UnitConverter(28.349) { From = "ounces", To = "grams" };
                UnitConverter cupsTolitConverter = new UnitConverter(4.226) { From = "cups", To = "litters" };
    
                string type;
                int done;
    
                done = 0;
    
                while(done == 0)
                {
                    {
                        type = Console.ReadLine();
    
                        if(type == "centi")
                        {
                            MakeConversion(centToInchesConverter);
                        }
    
                        else if(type == "feet")
                        {
                            MakeConversion(feetToInchesConverter);
                        }
    
                        else if(type == "km")
                        {
                            MakeConversion(kmsToMilesConverter);
                        }
    
                        else if(type == "miles")
                        {
                            MakeConversion(milesToFeetConverter);
                        }
    
                        else if(type == "grams")
                        {
                            MakeConversion(ozToGramsConverter);
                        }
    
                        else if(type == "cups")
                        {
                            MakeConversion(cupsTolitConverter);
                        }
    
                        else if(type == "end")
                        {
                            done = 1;
                        }
                    }
                }
            }
        }
    }
