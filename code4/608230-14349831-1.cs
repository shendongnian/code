    private void MakeCombo<T>(Combo combo, IEnumerable<T> list)
    {
        Type type = typeof(T);
        List<T> comboList = list.Where(x => ((String)type.GetField("Field1", (BindingFlags.Public | BindingFlags.Instance)).GetValue(x)).ToLower().Contains(m_SearchText.ToLower()));
        for (Int32 i = m_ItemOffset; i < m_OffsetEnd; ++i)
            combo.Items.Add(new ComboItem((String)type.GetField("Field1", (BindingFlags.Public | BindingFlags.Instance)).GetValue(list[i]), (String)type.GetField("Field2", (BindingFlags.Public | BindingFlags.Instance)).GetValue(list[i])));
    }
