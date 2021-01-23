    Using System.Linq;
     int[]  ar = { 1,2,3,4,5};
     int k = 1; //
     int[] ar1=  ar.Skip(k)            // Start with the last elements
                 .Concat(ar.Take(k)) // Then the first elements
                 .ToArray();
