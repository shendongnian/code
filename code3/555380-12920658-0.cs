    var listA = new List<int>();
    var dictA = new Dictionary<int,int>();
  
    int rangeStart = 0;
    int rangeEnd = 0;
    bool protectRange = false;
    // method is called externally 3000 times per second
    void ProducerThread(int a)
    {      
     listA.Add(a);
     dictA.Add(rangeEnd++,a);   
    }
    void ConsumerThread()
    {
     while(true)
     {
      Thread.Sleep(2000);
      int rangeInstance = rangeEnd;
      var listB = new List<int>();
      for( int start = rangeStart; start < rangeInstance; start++ ){
       listB.add(dictA[start]);
       rangeStart++;
      }
      //... processing listB data
      }
    }
