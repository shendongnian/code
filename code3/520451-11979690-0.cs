       bool enteringNames=true;
       do{
        String nextName = Console.ReadLine();
        if (nextName.CompareTo("Q")==0)
        {
           enteringNames=false;
        }
        else
        {
           p[i]=nextName;
        }
        i++;
      }
      while(enteringNames);
