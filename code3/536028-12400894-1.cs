      public ReadDiagnosticEntirePointValuesResponse()
        {
               GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
              .ToList()
              .ForEach(field => field.SetValue(this, new string[count]));
        }
