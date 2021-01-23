    using System.IO
    using (StreamWriter writer = new StreamWriter("C:\\out.txt"))
            {
                Console.SetOut(writer);
             }
    Console.WriteLine("the components are:");
            foreach (String compName in componentsList)
            { Console.WriteLine(compName); }
