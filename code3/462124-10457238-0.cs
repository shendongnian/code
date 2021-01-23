        for (int i = 1; i <= elementCount; i++) 
        { 
            var NodeIter = nav.SelectSingleNode("/GUI/window[@ID='"+i+"']/@name"); //This selects the @name attribute directly
            Console.WriteLine("{0}", NodeIter.Value); 
        }
