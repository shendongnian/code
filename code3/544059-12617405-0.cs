    public void Sort(int[] collection)
        {
            int inner, temp;
            for (int i = 1; i < collection.Length; i++)
            {
                temp = collection[i];
                     inner = i;
                while (inner > 0 && collection[inner - 1] >= temp)
                {
                    collection[i] = collection[inner - 1];
                    --inner;
                }
                collection[inner] = temp;
            }
            Console.WriteLine("Printing Insertion Sorted Items");
            Print();                           
        }
