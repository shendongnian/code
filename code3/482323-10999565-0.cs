    public Widget FindByCode(string code)
     {
      return 
                 _session
                     .Query<Widget>()
                     .FirstOrDefault(w => !w.IsDeleted && w.Code == code);
      }
