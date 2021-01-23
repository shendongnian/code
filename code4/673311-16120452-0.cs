    try
    {
        Assembly projectA = Assembly.Load("ProjectA"); // replace with actual ProjectA name 
        // despite all Microsoft's dire warnings about loading from a simple name,
        // you should be fine here as long as you don't have multiple versions of ProjectA
        // floating around
        foreach (Type t in projectA.GetTypes())
        {
            if (t.BaseType == typeof(Form))
            {
                var emptyCtor = t.GetConstructor(Type.EmptyTypes);
                if (emptyCtor != null)
                {
                    var f = (Form)emptyCtor.Invoke(new object[] { });
                    // t.FullName will help distinguish the unwanted entries and
                    // possibly later ignore them
                    string formItem = t.FullName + " // " + f.Text + " // " + f.Name;
                    checkedListBox1.Items.Add(formItem);
                }
            }
        }
    }
    catch(Exception err)
    {
        // log exception
    }
