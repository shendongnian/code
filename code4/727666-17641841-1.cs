    class Test
    {    
        unsafe static void Main()
        {
            var ch4 = new Chapter4Time { TimeLow = 100, MicroSeconds = 50 };
            var ieee1588 = *((IEEE_1588Time*) &ch4);
            Console.WriteLine(ieee1588.Seconds);
        }
    }
