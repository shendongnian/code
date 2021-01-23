    string user = string.Empty;
    foreach (var item in DbManager.GetOnline())
    {
        user += item;
    }
    MessageBox.Show(user);
