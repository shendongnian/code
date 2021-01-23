     public override bool Equals(Object obj)
     {
         if (obj is Dollar)
         {
             return this.Amount == ((Dollar)obj).Amount;
         }
         return false;
     }
