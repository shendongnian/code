     string innerMessage = e.InnerException != null ? e.InnerException.Message : string.Empty;
     if (args.IsTerminating)
         log.LogError(e.Message, e.Source, innerMessage);
     else
         log.LogWarning(e.Message, e.Source, innerMessage);
