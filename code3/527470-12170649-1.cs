    class myobject 
    {
         //override GetHashCode
         public override int GetHashCode()
         {
            unchecked // Overflow is fine, just wrap
            {
               int hash = 17;
               // Suitable nullity checks etc, of course :)
               hash = hash * 23 + recordNumber.GetHashCode();
               hash = hash * 23 + name.GetHashCode();
               return hash;
             }
         }
         //override Equals      
    }
