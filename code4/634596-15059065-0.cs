      public ViewResult Index(int? CId,int?SId,string name,int? p)
      {
            if (!CId.HasValue || !SId.HasValue)
            {
                CId = 1;
                SId = 1;
            }
      }
