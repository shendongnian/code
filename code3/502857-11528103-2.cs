    public static void fillObject(object [] obs, DataTable dt, Func<object> builder)
    {
       for (int j = 0; j < dt.Rows.Count; j++)
       {
          DataRow dr = dt.Rows[j];
          
          if (obs[j] == null)
             obs[j] = builder();
          fillObject(obs[j], dr);
       }
    }
