        private void DoSomething(Func<int[,],int,int[]> accessor)
       { 
           int[,] theData = {{1,1,1,1,1},{2,2,2,2,2}};           
           int[] someData = accessor(theData,1);
       }
       private void Working()
       {
           DoSomething(GetRow);
           
       }
       public int[] GetRow(int[,] data,int index)
       {
           List<int> numbers = new List<int>();
           for (int i = 0; i < data.GetLength(1); i++)
           {
               numbers.Add(data[index, i]);
           }
           return numbers.ToArray();
       }
