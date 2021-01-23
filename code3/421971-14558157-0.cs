    if(exp.GetType()==typeof(expType1))
    {
        if(exp.Message.Include("something went bad"))
        {
          if(exp.InnerException.Message == "Something inside went bad as well";
          {
            DoX();
            DoY();
          }
        }
    }
    else if (exp.GetType()==typeof(expType2))
    {
      DoZ();
      DoV();
    }
