    public void ChangeBoolValue(int index, int value)
    {
        bool[] Copy = new bool[4];
        BoolArray.CopyTo(Copy, 0);
        BoolArray = Copy;
          
        BoolArray[index] = value;
    }
