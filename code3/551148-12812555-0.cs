        public class State : Object {
       Boolean[,] grid = new Boolean[4,4];
    
       public State(Boolean[,] passedGrid){ //Constructor
           Array.Copy(passedGrid, grid, 16);
       }
    
       public override bool Equals(Object s2){ //Overloaded equals operator
             for (int x = 0; x < 4; x++){
                     for (int y = 0; y < 4; y++){
                          if (grid[x, y] != ((State)s2).grid[x, y]){
                                return false;
                            }
                        }
                    }
                    return true;
                }
    
    }
    
        
        class Program
        {
            Boolean[,] testArray = new Boolean[4, 4];
    
            public static void Main()
            {
                Program p = new Program();
                p.testContains(p.testArray);
            }
    
            public void testContains(Boolean[,] testArray)
            {
                Queue<State> testQueue = new Queue<State>();
                State s1 = new State(testArray);
                State s2 = new State(testArray);
                testQueue.Enqueue(s1);
                Boolean b = testQueue.Contains(s2);
                //b is true here
            }
    
        }
    }
