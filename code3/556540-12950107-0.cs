    public void sumAverageElements(int[] arr)
    {
         int size =arr.Length;
         int sum = 0;
         int average = 0;
    
         for (int i = 0; i < size; i++)
         {
              sum += arr[i];
         }
            
         average = sum / size; // sum divided by total elements in array
    
         Console.WriteLine("The Sum Of Array Elements Is : " + sum);
         Console.WriteLine("The Average Of Array Elements Is : " + average);
    }
