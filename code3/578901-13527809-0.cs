    namespace _121119_zionAVGfilter
    {
        class Program
        { 
            static void Main(string[] args)
        {
            int cnt = 0, zion, sum = 0;
            double avg;
            int flag = 0;
            Console.Write("Enter first zion \n");
            zion = int.Parse(Console.ReadLine());
            while (zion != -1)
            {                 
                while (zion < -1 || zion > 100)
                {
                    Console.Write("zion can be between 0 to 100 only! \nyou can rewrite the zion here, or Press -1 to see the avg\n");
                    zion = int.Parse(Console.ReadLine());
                    if(zion== -1)
                        flag = 1;
                }                
                cnt++;
                sum = sum + zion;
                if (flag == 1)
                    break;
                Console.Write("Enter next zion, if you want to exit tap -1 \n");
                zion = int.Parse(Console.ReadLine());
                if (cnt != 0) { }
            }
            if (cnt == 0)
            {
                Console.WriteLine("something doesn't make sence");
            }
            else
            {
                avg = (double)sum / cnt;
                Console.Write("the AVG is {0}", avg);                
            }            
            Console.ReadLine(); 
          }
        }
    }
