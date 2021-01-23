    using System;
    using System.Collections.Generic;
    // FirstOrDefault is part of the Linq API
    using System.Linq;
    
    namespace Foo {
        class Program {
            static void main (string [] args) {
                var d = new Dictionary<string, string> () {
                    { "one", "first" },
                    { "two", "second" },
                    { "three", "third" }
                };
                Console.WriteLine (d.FirstOrDefault (x => x.Value == "second").Key);
            }
        }
    }
