    class LongOrGuid
    {
         private Guid _guid;
         private long _long;
         private bool _isGuid = true;
    
         public LongOrGuid(Guid g)
         {
              _guid = g;
              _isGuid = true;
         }
    
         public LongOrGuid(long l)
         {
              _long = l;
              _isGuid = false;
         }
    
         public long Long
         {
              get
              {
                   if(_isGuid)
                   {
                        throw new NotSupportedException("This is a guid");
                   }
                   return _long;
              }
         }
    
         public Guid Guid
         {
              get
              {
                   if(!_isGuid)
                   {
                        throw new NotSupportedException("This is a long");
                   }
                   return _guid;
              }
         }
    
         public bool IsGuid
         {
              get
              {
                   return _isGuid;
              }
         }
    }
