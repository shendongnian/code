    public static void Main(string[] args)
       {
           List<string> Settings = new List<string>();
           Console.WriteLine("parameter qty = {0}", args.Length);
           for(int i = 0; i < args.Length; i++)
           {
               Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
               if (i>0)
                   {
                       // this gives you a nice iterable list of settings
                       Setting.Add(args[i]);
                   }
           }
           foreach(string setting in Settings)
               {
                   //do the desired action
               }
        }
