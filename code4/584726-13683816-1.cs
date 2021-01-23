    public static void DoConversions()
    {
        Type[] contents = CommandLine.Instance.TaskAssembly.GetExportedTypes();
        SortedDictionary<int, List<Type>> conversions = new SortedDictionary<int, List<Type>>();
        foreach (Type t in contents)
        {
            ConversionAttribute attr = FindAttribute(t);
            if (attr != null)
            {
                if (!conversions.ContainsKey(attr.ConversionOrder))
                {
                     conversions.Add(attr.ConversionOrder, new List<Type>());
                }
                conversions[attr.ConversionOrder].Add(t);
            }
        }
    
        foreach (int order in conversions.Keys)
        {
            foreach (Type t in conversions[order])
            {
                ConstructorInfo c = t.GetConstructor(new Type[] { typeof(CommandLine) });
                DataConversion d = (DataConversion)c.Invoke(new object[] { CommandLine.Instance });
                ConversionVersionStatus status = d.VersionStatus(CommandLine.Instance.TaskParameterValue("TAX_FULL_VERSION"));
                if ((status == ConversionVersionStatus.NoVersionSet) || (status == ConversionVersionStatus.Relevant))
                {
                    d.Log(String.Format(CultureInfo.InvariantCulture, "Started Conversion {0}", d.FriendlyName));
                    d.ExecuteTask();
                    d.Log(String.Format(CultureInfo.InvariantCulture, "Finished Conversion {0}", d.FriendlyName));
               }
               else
               {
                   if (status == ConversionVersionStatus.Discontinued)
                   {
                       d.Log(String.Format(CultureInfo.InvariantCulture, "Conversion {0} skipped as discontinued", d.FriendlyName));
                   }
                   else
                   {
                       d.Log(String.Format(CultureInfo.InvariantCulture, "Conversion {0} skipped as not yet relevant", d.FriendlyName));
                   }
               }
           }
       }
    }
