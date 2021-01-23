    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace DictionaryElementsGetter_Test {
    
      // class inherits from Dictionary<int, string>
      public class MyDictionary : Dictionary<int, string> {
        // new: hide element of base class to redefine it in derived class.
        //      see http://msdn.microsoft.com/en-us/library/435f1dw2.aspx
        // string this[int key]: create an indexer
        //                       (actually: replace the indexer of base class, because of "new")
        //                       see http://msdn.microsoft.com/en-us/library/2549tw02.aspx
        new public string this[int key] {
          get {
            string value;
            // out: pass argument by reference instead of by value
            //      This is the standard definition of TryGetValue.
            //      Beside the bool result that indicates the existence of the key-value-pair,
            //      TryGetValue also returns the value itself into this reference parameter (if key is found).
            //      see http://msdn.microsoft.com/en-us/library/ee332485.aspx
            if( !TryGetValue( key, out value ) ) {
              value = "abc" + key + "def";
              Add( key, value );
              // just to see when the getter really did an Add():
              Console.Write( "ADDED!... " );
            }
            return value;
          }
          // base: access element of the base class Dictionary<int, string>
          //       see http://msdn.microsoft.com/en-us/library/hfw7t1ce(v=vs.100).aspx
          set { base[key] = value; }
        }
      }
    
    
      class Program {
        static void Main( string[] args ) {
    
          var dict = new MyDictionary();
          dict[1] = "EXTERNAL VALUE";
    
          for( int i = 0; i < 3; i++ ) {
            Console.WriteLine( i + ": " + dict[i] );
          }
          /* 
          Output:
            ADDED!... 0: abc0def
            1: EXTERNAL VALUE
            ADDED!... 2: abc2def
          */
          for( int i = 0; i < 3; i++ ) {
            Console.WriteLine( i + ": " + dict[i] );
          }
          /* 
          Output:
            0: abc0def
            1: EXTERNAL VALUE
            2: abc2def
          */
    
          Console.ReadKey();
    
        }
      }
    }
