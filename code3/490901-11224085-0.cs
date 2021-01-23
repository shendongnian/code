    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication13
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (manytomanyEntities entities = new manytomanyEntities())
                {
                    List<B> bList = new List<B>();
    
                    A a = new A
                    {
                        Name = "Tim_A"
                    };
    
                    for (int i = 0; i < 100; i++)
                    {
                        B b = new B
                        {
                            Name = "Tim_B_" + i
                        };
    
                        entities.B.AddObject(b);
                    }
    
                    entities.A.AddObject(a);
    
                    entities.SaveChanges();
    
                }
            }
        }
    }
