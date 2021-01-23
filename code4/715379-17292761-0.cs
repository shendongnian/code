    static void Entwine(INotifyPropertyChanged source, object target)
    {
        source.PropertyChanged += (sender,args) =>
        {
            var prop = target.GetType().GetProperty(args.PropertyName);
            if(prop != null)
            {
                var field = prop.GetValue(target) as GeneralField;
                if(field != null)
                {
                    var newVal = source.GetType().GetProperty(args.PropertyName)
                                       .GetValue(source);
                    field.SetValue(newVal); // <=== some method on GeneralField
                }
            }
        };
    }
