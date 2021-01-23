    class testclass
    {
       private int _num = 0;
       private int _max = 0;
    
       public int Num
       {
          set { _num = value; }
          get { return _num; }
       }
    
       public int Max
       {
          set { _max = value; }
          get { return _max; }
       }
    
       public testclass()
       {
                Num = 3;  
                Max = 30; 
       }    
    }
    
    //To access Num or Max from a different class:
    
    testclass test = new testclass(null);
    Console.WriteLine(test.Num);
