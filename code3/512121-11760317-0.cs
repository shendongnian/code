    class Less7Holder
    {
       public List<int> g = new List<int>();
       public int mySum = 0;
    }
    
    void Main()
    {
        List<int> nu = new List<int>();
        nu.Add(2);
        nu.Add(1);
        nu.Add(3);
        nu.Add(5);
        nu.Add(2);
        nu.Add(1);
        nu.Add(1);
        nu.Add(3);
    
        var result  = nu .Aggregate(
           new LinkedList<Less7Holder>(),
           (Less7Holder,inItem) => 
           {
              if ((Less7Holder.Last == null) || (Less7Holder.Last.mySum + inItem > 7))
              {
                t = new Less7Holder();
                t.g.Add(inItem);
                mySum = inItem;
                Less7Holder.AddLast(t);
              }
              else
              {
                Less7Holder.Last.g.Add(inItem);
                Less7Holder.Last.mySum += inItem;
              }
              return Less7Holder;
           },
           (Less7Holder) => { return holdList.Select((h) => h.g );} );
     
    }
