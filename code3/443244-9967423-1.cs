    public void QuickSort(int[] array)
    {
        // Easiest way to get a copy of the array
        var newArray = (int[])array.Clone();
        ...
    }
    public void ReverseArray(int[] array)
    {
        var newArray = (int[])array.Clone();
        ...
    }
    public Program(int[] array)
    {      
        QuickSort(array);
        ReverseArray(array);
    }
