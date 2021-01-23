    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace CastTest {
        using FooList = List<Foo>;
        class Foo {}
        class Program {
            static void Main(string[] args) {
                FooList list = Program.GetFooList();
            }
            // Suppose this is some library method, and i don't have control over the return type
            static List<Foo> GetFooList() {
                return new List<Foo>();
            }
        }
    }
