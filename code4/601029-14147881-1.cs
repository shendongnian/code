      protected override IDictionary<Type, Type> GetViewModelViewLookup()
      {
          var toReturn = base.GetViewModelViewLookup();
          MvxTrace.Trace("Tracing viewModels and views");
          foreach (var kvp in toReturn)
          {
              MvxTrace.Trace("Seen pair {0} : {1}", kvp.Key.Name, kvp.Value.Name);
          }
          return toReturn;
      }
