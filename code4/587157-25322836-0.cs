            Console.WriteLine("enter length of the array");
            int n = int.Parse(Console.ReadLine());
            int[] myarray = new int[n];
            for (int i = 0; i < n ; i++)
            {
                Console.WriteLine("enter value of array" + " " + i);
                myarray[i]=int.Parse(Console.ReadLine());
            }
            int length = 1;
            int start = 0;
            int bestlength=0;
            int beststart=0;
            for (int i = 1; i < n; i++)
            {
                if (myarray[i - 1] == myarray[i])
                {
                    length++;
                    continue;
                }
                if (bestlength<length)
                {
                    bestlength = length;
                    beststart = start;
                }
                length = 1;
                start = i;
            }
            Console.WriteLine("the best sequence is");
            for (int j = beststart; j < bestlength + beststart; j++)
            {
                Console.Write(myarray[j] + ",");
            }
        }
    }
}
       
           
