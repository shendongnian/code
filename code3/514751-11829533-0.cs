    public List<IAction> Dispatch(string[] arg)
    {
       int time=0;
       List<IAction> t = new List<IAction>(10);
       for (int j = 0; j < arg.Length; j++)
       {
           if (!String.IsNullOrEmpty(arg[j]) && arg[j][0] == '/')
           {
               Options opt = new Options();                   
               time = opt.Option(arg[j]);
           }
           else
           {
               if (int.Parse(arg[j]) >= 0 && int.Parse(arg[j]) <= 20)
               {
                   t.Add(new ComputeParam(int.Parse(arg[j])));
                   // Don't need to increment i                
               }
           }
       }
       for (int z = 0; z < t.Count; z++)
       {
           ((ComputeParam)t[z]).Time = time;
       }
       return t;
    }
