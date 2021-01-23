     if (args.IsTerminating)
     {
         if(e.InnerException != null)
             log.LogError(e.Message, e.Source, e.InnerException.Message);
         else
             log.LogError(e.Message, e.Source, string.Empty);
     }
     else
     {
         if(e.InnerException != null)
              log.LogWarning(e.Message, e.Source, e.InnerException.Message);
         else
              log.LogWarning(e.Message, e.Source, string.Empty);
     }
