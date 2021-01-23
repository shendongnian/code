    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
        public enum RoleType {
            Default = 10,
            Guest = 20,
            User = 30,
            Admin = 40,
            Super = 50
        }
    
    
        class Program {
            static void Main(string[] args) {
                Console.WriteLine(RoleType.Guest.ToString());
                Console.ReadLine();
            }
        }
