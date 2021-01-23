            SubLibClassA.libMethod(1);
            Console.WriteLine(SubLibClassA.GetNum());  // 1
            
            SubLibClassB.libMethod(2);
            Console.WriteLine(SubLibClassB.GetNum());  // 2
            Console.WriteLine(SubLibClassA.GetNum()); // still 1! Yay! :D
