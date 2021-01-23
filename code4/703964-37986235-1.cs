    public static void SetOptions<T>(this DropDownList dropDownList)
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("Type must be an enum type.");
        }
        dropDownList.Items.AddRange(Enum
            .GetValues(typeof(T))
            .Cast<Enum>()
            .Select(x => new ListItem(x.ToString(), Convert.ToInt32(x).ToString()))
            .ToArray());
    }
