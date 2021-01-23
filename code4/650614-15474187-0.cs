    int GetSumString(string s)
    {
      // Convert everything to int[], easier that way in .NET
      var numbersOrg = s.Select(t => int.Parse(t.ToString())).ToArray();
  
      // Its possible to optimize by using ienumerable and lazy evaluation i guess, but I'm lazy :)
      var queue = new Queue<int[]>();
      queue.Enqueue(numbersOrg);
  
      while (queue.Any())
      {
          var numbers = queue.Dequeue();   
  
          var firstHalf = numbers.Take(numbers.Length / 2).Sum();
          var secondHalf = numbers.Skip(numbers.Length / 2).Sum();
          // It must be of even length (% 2) and the sum of the first half must be equal to the last half.
          if (numbers.Length % 2 == 0 && firstHalf == secondHalf)
              return numbers.Length;
  
          // Console.WriteLine("tried: " + string.Join("", numbers) + " gave (" + firstHalf + "," + secondHalf + ")");
          // Only enqueue when we have something left in the array
          if (numbers.Length > 1)
          {
              queue.Enqueue(numbers.Take(numbers.Length - 1).ToArray());
              queue.Enqueue(numbers.Skip(1).ToArray());
          }
      }
      return 0;
    }
