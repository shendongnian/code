     class Program
      {
        static void Main(string[] args)
        {
          int[] myInt = new[] { 2, 1, 0, 3, 4 };
    
          // there is nothing to sort at this time, but this is how I would make a new list matching your index....
          var myTests = (from x in myInt select new Tests(x, "whatever")).ToList();
    
          myTests.ForEach(i => Console.WriteLine("{0} {1}", i.iD, i.myString));
    
    
          // So assuming that you are starting with an unsorted list....
          // We create and priont one....
          myTests = new List<Tests>();
          for (int i = 0; i < myInt.Length; i++)
          {
            myTests.Add(new Tests(i, "number " + i));
          }
    
          Console.WriteLine("unsorted ==");
          myTests.ForEach(i => Console.WriteLine("{0} {1}", i.iD, i.myString));
    
          // And this will perform the sort based on your criteria.
          var sorted = (from x in myInt
                        from y in myTests
                        where y.iD == x
                        select y).ToList();
    
          // And output the results to prove it.
          Console.WriteLine("sorted ==");
          sorted.ForEach(i => Console.WriteLine("{0} {1}", i.iD, i.myString));
    
          Console.Read();
        }
      }
