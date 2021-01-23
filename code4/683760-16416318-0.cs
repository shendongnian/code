    int[] ArrTotal(int[] array1, int[] array2)
    {
        if ((array1 == null) && (array2 == null))
            return new int[0]; // Zero length array - put some other number here if you need!
        else if (array1 == null)
            return (int[])array2.Clone(); // Result will just be a copy of the non-null array.
        else if (array2 == null)
            return (int[]) array1.Clone(); // Result will just be a copy of the non-null array.
        else
        {
            int skip = Math.Min(array1.Length, array2.Length);
            return Enumerable
                .Zip(array1, array2, (i1, i2) => i1 + i2)
                .Concat(array1.Skip(skip))
                .Concat(array2.Skip(skip))
                .ToArray();
        }
    }
