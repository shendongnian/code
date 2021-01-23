    string removeidat(string[] id, string at)
    {
         string toren = "";
         int remat = -1;
         if (at=="first")
         {
              remat = 0;
         }
         else if (at == "middle")
         {
              remat = id.Length / 2;
         }
         else
         {
              remat = id.GetUpperBound(0);
         }
         for (int i = 0; i < id.GetUpperBound(0); i++)
         {
              if (i!=remat)
              {
                   toren += id[i] + ",";
              }
         }
         if (toren.Length>0)
         {
              toren = toren.Substring(0, toren.Length - 1);
         }
         return toren;
    }
