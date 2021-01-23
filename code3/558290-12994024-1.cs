    > class SomeClass
      {
          object id;
      
          public object Id
          {
              get
              {
                  return id;
              }
          }
      }
    > var t = typeof(SomeClass)
          ;
    > t
    [Submission#1+SomeClass]
    > t.GetField("id")
    null
    > t.GetField("id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    > t.GetField("id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
    [System.Object id]
    > 
