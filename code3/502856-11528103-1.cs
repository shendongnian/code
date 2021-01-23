    Dictionary<Type, Func<object>> sBuilders = new Dictionary<Type, Func<object>>
    {
       { typeof(Type1), () => new Type1() },
       { typeof(Type2), () => new Type2() },
       // etc...
    };
    public static void fillObject(object [] obs, DataTable dt, Type pType)
    {
       for (int j = 0; j < dt.Rows.Count; j++)
       {
          DataRow dr = dt.Rows[j];
          
          if (obs[j] == null)
             obs = sBuilders[pType]();
          fillObject(obs[j], dr);
       }
    }
