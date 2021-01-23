     // for each example. For LINQ just use Where then check the length of the IEnumerable
     // if it 0 then item is unique.
     bool duplicate = false;
     foreach (string s in MyQueue)
     {
         if (s == inputString)
             duplicate = true;
     }
     
     if (!duplicate)
         MyQueue.Enqueue(inputString);
     // to get first item added simply do
     string firstIn = MyQueue.Dequeue();
