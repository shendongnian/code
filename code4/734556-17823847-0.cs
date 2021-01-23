    int x = 10;
    int y = 10;
    int[,] array = new int[x, y];
    
      // iterate over the left coordinate
    foreach(int i in Enumerable.Range(0, x))
    {
      array[i,0] = 1;    //bottom
      array[i,y-1] = 1;  //top
    }
    
      // iterate over the right coordinate
    foreach(int i in Enumerable.Range(0, y))
    {
      array[0,i] = 1;    //left
      array[x-1,i] = 1;  //right
    }
