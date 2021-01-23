       public int[] UniqeRandomArray(int size , int Min , int Max ) {
            int [] UniqueArray = new int[size];
            Random rnd = new Random();
            int Random;
            for (int i = 0 ; i < size ; i++) {
                Random = rnd.Next(Min, Max);
                for (int j = i; j >= 0 ; j--) {
                    if (UniqueArray[j] == Random)
                    { Random = rnd.Next(Min, Max); j = i; }
                               
                }
                UniqueArray[i] = Random;
            
            }
            return UniqueArray;
        
        }
