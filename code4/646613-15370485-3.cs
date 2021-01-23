        private void DoSomething(Func<int[,],int,int[]> accessor, int Idx)
       { 
           int[,] theData = {{1,1,1,1,1},{2,2,2,2,2}};           
           int[] someData = accessor(theData,Idx);
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
