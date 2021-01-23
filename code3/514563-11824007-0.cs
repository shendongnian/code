    public class ArgsParser
    {
    
       public DataRC Dispatch(string arg)
       {
           DataRC dResult = new DataRC();
           int time;
           int i = 0;
           dResult.aObj = new object[10];
           if (int.Parse(arg) >= 0 && int.Parse(arg) <= 20)
           {
               dResult.aObj[i] = new ComputeParam(int.Parse(arg));
           }
           else
           {
               if (arg[0] == '/' && arg[1] == 't')
               {
                   Options opt = new Options();
                   // Is this where you need the time?
                   dResult.dtTime = opt.Option(arg);
               }
           }
           return dResult;
       }
     }
    }
