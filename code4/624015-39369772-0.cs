       using System; 
     using System.Collections.Generic; 
     using System.Linq;  
    using System.Text; 
     using System.Threading.Tasks;
    
    namespace Practice {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter the size");
                int n = Convert.ToInt32(Console.ReadLine());
                int[] mynum = new int[n];
                Console.WriteLine("Enter the Numbers");
                for (int p = 0; p < n;p++ )
                {
                    mynum[p] = Convert.ToInt32(Console.ReadLine());
    
                }
                Console.WriteLine("The number are");
                    foreach(int p in mynum)
                    {
                        Console.WriteLine(p);
                    }
                    for (int i = 0; i < n;i++ )
                    {
                        for(int j=i+1;j<n;j++)
                        {
                            if(mynum[i]>mynum[j])
                            {
                                int x = mynum[j];
                                mynum[j] = mynum[i];
                                mynum[i] = x;
                            }
                        }
                    }
                    Console.WriteLine("Sortrd data is-");
                foreach(int p in mynum)
                {
                    Console.WriteLine(p);
                }
                        Console.ReadLine();
            }
        } }
