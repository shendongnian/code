    if (t.BaseType == typeof(Form))
    {
        var emptyCtor = t.GetConstructor(Type.EmptyTypes);
        if(emptyCtor != null)
        {
            var f = (Form)emptyCtor.Invoke(new object[]{});
            string FormText = f.Text;
            string FormName = f.Name;
            checkedListBox1.Items.Add("" + FormText + "//" + FormName + "");
        }
    }
