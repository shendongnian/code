        public struct SomeStruct {
           public object AutoProp1 {get;set;}
           public object AutoProp2 {get;set;}
           public SomeStruct() : this() //must use this
           {
              AutoProp1 = someObject;
              AutoProp2 = someObject;
           }
        }
