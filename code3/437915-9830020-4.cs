    public static ValueList ToValueList(this UltraGridColumn cl, string vlKey, Type t)
    {
        ValueList vl = new ValueList();
        if (vlKey != string.Empty) vl.Key = vlKey;
        if (t.IsEnum == true)
        {
            // Get enum names
            string[] names = Enum.GetNames(t);
            Array a = Enum.GetValues(t);
            int i = 0;
            foreach (string s in names)
                vl.ValueListItems.Add(a.GetValue(i++), s.Replace("_", " "));
        }
        cl.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
        return vl;
    }
