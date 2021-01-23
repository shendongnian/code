        private static int[] Merge(int[] array1, int[] array2)
        {
            int N=array1.Length+array2.Length;
            Queue<int> Q1=new Queue<int>(array1);
            Queue<int> Q2=new Queue<int>(array2);
            Queue<int> result=new Queue<int>(N);
            for(int k=0; k<N; k++)
            {
                if(Q1.Count==0)
                {
                    result.Enqueue(Q2.Dequeue());
                }
                else if(Q2.Count==0)
                {
                    result.Enqueue(Q1.Dequeue());
                }
                else
                {
                    result.Enqueue(
                        Q1.Peek()<Q2.Peek()?
                        Q1.Dequeue():
                        Q2.Dequeue());
                }
            }
            return result.ToArray();
        }
