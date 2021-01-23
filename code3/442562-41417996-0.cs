    int max = 5; //the fixed size of your array.
    int[] inArray = new int[5] {0,0,0,0,0}; //initial values only.
    void putValueToArray(int thisData)
    {
      //let's do the magic here...
      Array.Copy(inArray, 1, inArray, 0, max-1);
      inArray[max-1] = thisData;
    }
