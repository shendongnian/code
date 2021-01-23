    private List<string> list = new List<string>();
    private List<string> rslt = new List<string>();            
    list.Add("math");
    list.Add("science");
    list.Add("math");
    list.Add("science");
    foreach (string i in list)
    {
         rslt.Add(i);
    }
    foreach (string i in list)
    {
         if (list.Count<string>(f => f == i) > 1)
         {
              int cnt = 1;
              int idx = 0;
              foreach (string j in list)
              {
                   if (j == i)
                   {
                        rslt[idx] = cnt.ToString() + "_" + j;
                        cnt++;
                   }
                   idx++;
               }
          }
     }
