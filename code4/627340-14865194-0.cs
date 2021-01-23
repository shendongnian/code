            string name, age, favColor;
            int num1, num2, sum, mult, subs; 
            float div;
            Console.WriteLine("What is your name? "); 
            //Start a new line and write ..
            name = Console.ReadLine(); 
            //Read the whole line
            Console.WriteLine("\nHello, {0}", name); 
            //{0} stands for the first variable you refer to after the, etc
            Console.WriteLine("How old are you? ");
            age = Console.ReadLine();
            Console.WriteLine("\nSo you are {0}, I thought that you were older!", age);
            // something new.. \n refers to a "new line", so instead of writing Console.Writeline(); you can use this
            Console.WriteLine("What is your favorite Color? ");
            favColor = Console.ReadLine();
            Console.WriteLine("{0} is a cool color!\n", favColor);
            Console.WriteLine("Nice meeting you, {0}", name);
            Console.WriteLine("Have a good day!\n");
            Console.WriteLine("Let us do some operations, {0}", name);
            Console.WriteLine("Please enter a number: ");
            num1 =  Convert.ToInt16(Console.ReadLine());
            //int.TryParse(Console.ReadLine(), out num1);
            //Another way is to "try parse", try converting a string to an integer
            Console.WriteLine("\nPlease enter another number: ");
            num2 = Convert.ToInt16(Console.ReadLine());
            //int.TryParse(Console.ReadLine(), out num2);
            //Another way is to "try parse", try converting a string to an integer where out is the returning variable
            sum = num1 + num2;
            mult = num1 * num2;
            subs = num1 - num2;
            div = num1 / num2;
            Console.WriteLine("\nAlright, {0}", name);
            Console.WriteLine("Let us blow up your mind!\n");
            //Again use {0} ... which writes easier than having to use + every time,
            //its not wrong but its easier this way
            Console.WriteLine("{0} + {1} = {2}", num1, num2, sum);
            Console.WriteLine("{0} * {1} = {2}", num1, num2, mult);
            Console.WriteLine("{0} - {1} = {2}", num1, num2, subs);
            Console.WriteLine("{0} / {1} = {2}", num1, num2, div);
            Console.WriteLine("\nMindblown, Right?");
            Console.ReadLine();
            //Console.ReadLine(); at the end to prevent the program from closing
