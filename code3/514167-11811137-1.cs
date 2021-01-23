      public class MyCounter
        {
            public  int cnt;
        }  
        public static readonly MyCounter mc = new MyCounter();
        public static void FillRow2(Object obj, out int val, out int index)
        {
            val = (int.Parse((string) obj)*2);
    
            index = mc.cnt++;
        }
