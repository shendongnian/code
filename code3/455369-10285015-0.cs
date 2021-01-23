       namespace MyNameSpace
        {
            using System;
            using System.ServiceModel;
    
            [CollectionDataContract(Name = "Somethings", ItemName = "SomethingDC")]
            public class CustomList<T> : List<T>
            {
                public CustomList()
                    : base()
                {
                }
    
                public CustomList(T[] items)
                    : base()
                {
                    foreach (T item in items)
                    {
                        Add(item);
                    }
                }
            }
    
    
            [MessageContract]
            public class FindSomethingResponse
            {
                [MessageBodyMember(Order = 1)]
                public CustomList<SomethingDC> response;
            }
        }
