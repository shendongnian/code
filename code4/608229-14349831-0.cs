    private void MakeCombo<T>(Combo combo, IEnumerable<T> list)
    {
        List<T> comboList = list.Where(x => ((String)typeof(x).GetField("Field1", BindingFlags.Public).GetValue(x)).ToLower().Contains(searchText.ToLower()));
        for (Int32 i = itemOffset; i < endOffset; ++i)
            combo.Items.Add(new ComboItem((String)typeof(list[i]).GetField("Field1", BindingFlags.Public).GetValue(list[i]), (String)typeof(list[i]).GetField("Field2", BindingFlags.Public).GetValue(list[i])));
    }
