    public class ArgsParser
    {
       public object[] aObj { get; set;}
       public DateTime dtTime {get; set;}
       public ArgsParser(string arg)
       {
           int time;
           int i = 0;
           aObj = new object[10];
           if (int.Parse(arg) >= 0 && int.Parse(arg) <= 20)
           {
               aObj[i] = new ComputeParam(int.Parse(arg));
           }
           else
           {
               if (arg[0] == '/' && arg[1] == 't')
               {
                   Options opt = new Options();
                   // Is this where you need to time?
                   dtTime = opt.Option(arg);
               }
           }
       }
     }
    }
