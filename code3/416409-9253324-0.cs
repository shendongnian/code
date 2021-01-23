    public static void AssignFrom(this object destination, object source) {
      Type dest_type = destination.GetType();
      Type source_type = source.GetType();
      var matching_props = from d in dest_type.GetProperties()
                            join s in source_type.GetProperties()
                            on d.Name equals s.Name
                            where d.IsWritable() && s.IsReadable()
                            select new {
                              source = s,
                              destination = d
                            };
      foreach (var prop in matching_props) {
        prop.destination.SetValue(destination, prop.source.GetValue(source, null), null);
      }
    }
