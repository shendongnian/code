    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
    
        class Vertebra {
            public string name { get; set; }
            public double height { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<Vertebra> Vertebrae = new List<Vertebra>() {
                    new Vertebra() {name = "C7", height = 0.0000000},
                    new Vertebra() {name = "T1", height = 0.0391914}
                    //etc
                };
    
                //find height by name:
                double H = Vertebrae.Single(v => v.name == "C7").height;
    
                //find name by height:
                string N = Vertebrae.Single(v => v.height == 0.0391914).name;
    
            }
        }
    
    }
