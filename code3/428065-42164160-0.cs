    static void Main(string[] args)
    {
       
       
            Console.WriteLine("Enter number:");
            int fnum = 0;
            bool chek = Int32.TryParse(Console.ReadLine(),out fnum);            
        
            Console.WriteLine("Enter number:");
            int snum = 0;
            chek = Int32.TryParse(Console.ReadLine(),out snum);
            Console.WriteLine("Enter number:");
            int thnum = 0;
            chek = Int32.TryParse(Console.ReadLine(),out thnum);
            int[] arr = AddToArr(fnum,snum,thnum);
            IOrderedEnumerable<int> oarr = arr.OrderBy(delegate(int s)
            {  
                return s;
            });
            Console.WriteLine("Here your result:");
           
        
            oarr.ToList().FindAll(delegate(int num) {
                Console.WriteLine(num);
                return num > 0;
             
            });
           
            
    }
    
    
    public static int[] AddToArr(params int[] arr) {
        return arr;
    }
 
