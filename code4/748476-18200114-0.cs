    int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 
    IEnumerator ie = numbers.GetEnumerator();
    while(ie.MoveNext()){
      if((int)ie.Current < 5) Console.Write(ie.Current + "  ");
    }
