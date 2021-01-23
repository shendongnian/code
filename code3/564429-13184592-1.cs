    public partial class MySelector : UserControl
    {
        class Record
        {
            public object Display { get; set; }
            public object Value { get; set; }
        }
        ....
        string MyDisplayMember { get; set; }
        string MyValueMember { get; set; }
        string MyExternalMember { get; set; }
        ....
        static Object Filter(MySelector sender, Object criterium)
        {
            IQueryable source = sender.MySource as IQueryable;
            if (source == null) return null;
            List<Record> result = new List<Record>();
            // drawback: this foreach loop will trigger a unfiltered SQL command.
            foreach (var record in source)
            {
                MethodInfo DisplayGetter = null;
                MethodInfo ValueGetter = null;
                bool AddRecord = false;
                foreach (PropertyInfo property in record.GetType().GetProperties())
                {
                    if (property.Name == sender.MyDisplayMember) 
                    {
                        DisplayGetter = property.GetGetMethod();
                    }
                    else if (property.Name == sender.MyValueMember)
                    {
                        ValueGetter = property.GetGetMethod();
                    }
                    else if (property.Name == sender.MyExternalMember)
                    {
                        MethodInfo ExternalGetter = property.GetGetMethod();
                        if (ExternalGetter == null)
                        {
                            break;
                        }
                        else
                        {
                            object external = ExternalGetter.Invoke(record, new object[] { });
                            AddRecord = external.Equals(criterium);
                            if (!AddRecord)
                            {
                                break;
                            }
                        }
                    }
                    if (AddRecord && (DisplayGetter != null) && (ValueGetter != null))
                    {
                        break;
                    }
                }
                if (AddRecord && (DisplayGetter != null) && (ValueGetter != null))
                {
                    Record r = new Record();
                    r.Display = (DisplayGetter == null) 
                        ? null 
                        : DisplayGetter.Invoke(record, new object[] { });
                    r.Value = (ValueGetter == null) 
                        ? null 
                        : ValueGetter.Invoke(record, new object[] { });
                    result.Add(r);
                }
            }
            return result;
        }
    }
