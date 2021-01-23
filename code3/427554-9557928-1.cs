    list<int> PastList=new PastList<int>();
    private void Choоse()
    {
       int i = Recurs();
       PastList.Add(i);
    }
    private int Recurs()
    {
       int i;
            
       i = rnd.Next(0, 99);
       if (PastList.Contains(i))
       {
           i = Recurs();
       }
            
       return i;
    }
