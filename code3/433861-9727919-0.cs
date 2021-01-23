    publicvoid PerformQuery<T>(EntityQuery<T> qry, EventHandler<EntityResultsArgs<T>> evt, object pUserState = null, bool NoRecordsThrow = False, LoadBehavior pLoadBehavior = LoadBehavior.MergeIntoCurrent ) where T : Entity
    {
      ModelDataContext.Load<T>(
        qry,
        pLoadBehavior,
        r =>
        {
          if (evt != null)
          {
            try
            {
              if (r.HasError)
              {
    #if DEBUG
                System.Diagnostics.Debugger.Break();
    #endif
                //internal class to record error messages
                AppMessages.ErrorMessage.Display(string.Concat(r.Error.Message, Environment.NewLine, "------------------------", "------- Stack Trace ------", Environment.NewLine, r.Error.StackTrace));
              }
              else if (r.Entities.Count() > 0 || NoRecordsThrow)
                evt(this, new EntityResultsArgs<T>(r.Entities, r.UserState));
            }
            catch (Exception ex)
            {
    #if DEBUG
              System.Diagnostics.Debugger.Break();
    #endif
              evt(this, new EntityResultsArgs<T>(ex));
            }
          }
        },
        pUserState);
    }
