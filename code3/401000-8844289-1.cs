    class Class1
        {
            public void DoQstuff()
            {
              Queue numbers = new Queue();
    
              foreach (int number in new int[4]{1,2,3,4})
              {
                  numbers.Enqueue(number);
                  Console.WriteLine(number + " has joined the queue");
              }
              foreach (int number in numbers)
              {
                  Console.WriteLine(number);
              }
              while(numbers.Count > 0)
              {
                  int number = (int)numbers.Dequeue();
                  Console.WriteLine(number + " has left the queue");
              }
            }
        }
