    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Planets
    {
        public class Planet
        {
            private string name;
            public string Name
            {
                get { return name; }
                set { this.name = value; }
            }
        
            private float diameter;
            public float Diameter
            {
                get { return diameter; }
                set { this.diameter = value; }
            }
            private int cntContinents;
            public int CntContinents
            {
                get { return cntContinents; }
                set { this.cntContinents = value; }
            }
     
            public Planet()
            {
                Console.WriteLine("Constructor 1");
                this.name = "nameless";
                this.diameter = 0;
                this.cntContinents = 0;
            }
            public Planet(string n, float d, int k)
            {
                Console.WriteLine("Constructor 2");
                this.name = n;
                this.diameter = d;
                this.cntContinents = k;
            }
        }
    }
