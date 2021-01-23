    public int GetHashCode(Pairing obj)
    {
         if (obj==null) return 0;
         var hc1 = obj.Index.GetHashCode();
         var hc2 = obj.Length.GetHashCode();
         var hc3 = obj.Offset.GetHashCode();
    
         return hc1 ^ hc2 ^ hc3;
   }
