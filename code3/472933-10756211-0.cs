    RuntimeTypeModel.Default.DynamicTypeFormatting += (sender, args) =>
    {
        Type type;
        if(!yourTypeMap.TryGetValue(args.FormattedName, out type))
        {
            type = typeof (NilContainer);
        }
        args.Type = type;
    };
