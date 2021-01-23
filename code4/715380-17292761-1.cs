    static void Entwine(INotifyPropertyChanged source, object target)
    {
        var sourceAccessor = ObjectAccessor.Create(source);
        var targetAccessor = ObjectAccessor.Create(target);
        source.PropertyChanged += (sender, args) =>
        {
            var field = targetAccessor[args.PropertyName] as GeneralField;
            if (field != null)
            {
                var newVal = sourceAccessor[args.PropertyName];
                field.SetValue(newVal);
            }
        };
    }
