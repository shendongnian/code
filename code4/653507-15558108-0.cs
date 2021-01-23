    public Type EnumType { get; private set; }
    public void SetEnum<T>(T defaultValue) where T : struct, IConvertible
    {
        SetEnum(typeof(T));
        this.Text = (defaultValue as Enum).GetLabel();
    }
    public void SetEnum<T>() where T : struct, IConvertible
    {
        SetEnum(typeof(T));
    }
    private void SetEnum(Type type)
    {
        if (type.IsEnum)
        {
            EnumType = type;
            ValueMember = "Value";
            DisplayMember = "Display";
            var data = Enum.GetValues(EnumType).Cast<Enum>().Select(x => new
            {
                Display = x.GetLabel(), // GetLabel is a function to get the text-to-display for the enum
                Value = x,
            }).ToList();
            DataSource = data;
            this.Text = data.First().Display;
        }
        else
        {
            EnumType = null;
        }
    }
    public T EnumValue<T>() where T : struct, IConvertible
    {
        if (typeof (T) != EnumType) throw new InvalidCastException("Can't convert value from " + EnumType.Name + " to " + typeof (T).Name);
        return (T)this.SelectedValue;
    }
