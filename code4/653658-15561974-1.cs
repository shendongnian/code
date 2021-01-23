        int c=0;
    
        foreach(var item in myDictionary)
        {
             c++;
             if(c==1)
             {
                 myFirstVar = item.Value;
             }
             else if(c==2)
             {
                 mySecondVar = item.Value;
             }
              ......
        }
