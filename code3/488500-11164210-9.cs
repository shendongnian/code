    using System;
    using System.Collections.Generic;
    
    class Program {
        static void Main(string[] args) {
            var goodmap = typeof(Derived).GetInterfaceMap(typeof(IEnumerable<int>));
            var badmap = typeof(int[]).GetInterfaceMap(typeof(IEnumerable<int>));  // Kaboom
        }
    }
    abstract class Base { }
    class Derived : Base, IEnumerable<int> {
        public IEnumerator<int> GetEnumerator() { return null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
