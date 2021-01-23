    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace struct_test
    {
        class Program
        {
            public struct Point
            {
                public int x, y;
    
                public Point(int x)
                {
                    this.x = x;
                    this.y = 5;
                }
    
                public Point(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
                // It will break with this constructor. If uncommenting this one
                // comment out the other one with only one integer, otherwise it
                // will fail because you are overloading with duplicate parameter
                // types, rather than what I'm trying to demonstrate.
                /*public Point(int y)
                {
                    this.y = y;
                }*/
            }
    
            static void Main(string[] args)
            {
                // Declare an object:
                Point myPoint;
                //Point myPoint = new Point(10, 20);
                //Point myPoint = new Point(15);
                //Point myPoint = new Point();
    
                // Initialize:
                // Try not using any constructor but comment out one of these
                // and see what happens. (It should fail when you compile it)
                myPoint.x = 10;
                myPoint.y = 20;
    
                // Display results:
                Console.WriteLine("My Point:");
                Console.WriteLine("x = {0}, y = {1}", myPoint.x, myPoint.y);
    
                Console.ReadKey(true);
            }
        }
    }
