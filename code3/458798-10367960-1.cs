    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            struct addition_pairs{
                public int first;
                public int second;
            }
    
            static void Main(string[] args)
            { 
                
             List<addition_pairs> main_list;
             main_list = new List<addition_pairs>();
           //TODO call populate_list and choose how many sets you want.
        
            }
    
            private void populate_list(int how_many, List<addition_pairs> list)
            {
                for (int i = 0; i < how_many; i++)
                {
                    Random random = new Random();
                    int randomNumber1 = random.Next(0, 10);
                    addition_pairs insert = new addition_pairs();
                    insert.first = randomNumber1;
                    insert.second = random.Next(0, 10-randomNumber1);
                    list.Add(insert);
                }
    
            }
        }
    }
