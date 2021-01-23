    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    
    namespace IntIntKeyedCollection
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                Guid findGUID = Guid.NewGuid();
                GUIDkeyCollection gUIDkeyCollection = new GUIDkeyCollection();
                gUIDkeyCollection.Add(new GUIDkey(findGUID));
                gUIDkeyCollection.Add(new GUIDkey(Guid.NewGuid()));
                gUIDkeyCollection.Add(new GUIDkey(Guid.NewGuid()));
                GUIDkey findGUIDkey = gUIDkeyCollection[findGUID];  // lookup by key (behaves like a dict)
                Console.WriteLine(findGUIDkey.Key);
                Console.WriteLine(findGUIDkey.GetHashCode());
                Console.WriteLine(findGUID);
                Console.WriteLine(findGUID.GetHashCode());
                Console.ReadLine();
            }
            public class GUIDkeyCollection : KeyedCollection<Guid, GUIDkey>
            {
                // This parameterless constructor calls the base class constructor 
                // that specifies a dictionary threshold of 0, so that the internal 
                // dictionary is created as soon as an item is added to the  
                // collection. 
                // 
                public GUIDkeyCollection() : base() { }
    
                // This is the only method that absolutely must be overridden, 
                // because without it the KeyedCollection cannot extract the 
                // keys from the items.  
                // 
                protected override Guid GetKeyForItem(GUIDkey item)
                {
                    // In this example, the key is the part number. 
                    return item.Key;
                }
            }
            public class GUIDkey : Object
            {
                private Guid key;
                public Guid Key
                {
                    get
                    {
                        return key;
                    }
                }
                public override bool Equals(Object obj)
                {
                    //Check for null and compare run-time types.
                    if (obj == null || !(obj is GUIDkey)) return false;
                    GUIDkey item = (GUIDkey)obj;
                    return (Key == item.Key);
                }
                public override int GetHashCode() { return Key.GetHashCode(); }
                public GUIDkey(Guid guid)
                {
                    key = guid;
                }
            }
        }
    }
