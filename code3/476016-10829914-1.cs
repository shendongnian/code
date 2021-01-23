    if (ColumnType(DdlColumn1.SelectedValue) == "Text" && DdlOperator1.SelectedItem.Text=="LIKE")
    {
        string s = TxtValue1.Text;
        Char c = s[s.Length - 1];
        string s1 = s.Substring(0, s.Length - 1) + ((Char)(c + 1));
        string clause = string.Format("{0} >= \"{1}\" and {0} < \"{2}\"", DdlColumn1.SelectedValue, s, s1);
        sb.Append(clause);
    }
