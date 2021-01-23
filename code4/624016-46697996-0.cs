        public void BubbleSortNum()
        {
            int[] a = {10,5,30,25,40,20};
            int length = a.Length;
            int temp = 0; 
            for (int i = 0; i <length; i++)
            {               
                for(int j=i;j<length; j++)
                {
                    if (a[i]>a[j])
                    {
                        temp = a[j];
                        a[j] = a[i];
                        a[i] = temp;
                    }     
                }
               Console.WriteLine(a[i]);
            }       
         }
      
