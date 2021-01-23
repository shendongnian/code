	using System;
	using System.Collections.Generic;
	namespace OrderExample {
	    public class A {
	        public int Order { get; set; } 
	    }
	    public class Program {
	        // Change order so that a is ordered between b and c.
	        public static void SetOrder(List<A> list, A a, A b, A c) {
	            list.Sort((x, y) => x.Order.CompareTo(y.Order));
	            var linkedList = new LinkedList<A>(list);
	            var bNode = linkedList.Find(b);
	            if (bNode != null) {
	                linkedList.Remove(a);
	                linkedList.AddAfter(bNode, a);
	                var i = 0;
	                foreach (var value in linkedList) {
	                    value.Order = i++;
	                }                
	            }
	        }
	        static void Main() {
	            var a0 = new A {Order = 0};
	            var a1 = new A {Order = 1};
	            var a2 = new A {Order = 2};
	            var a3 = new A {Order = 3};
	            var list = new List<A> {a0, a1, a2, a3};
	            
	            SetOrder(list, a0, a2, a3);
	            foreach (var a in list) {
	                Console.Out.WriteLine(a.Order);
	            }
	            Console.ReadKey();
	        }
	    }
	}
