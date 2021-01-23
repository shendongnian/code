    for (int i = formsList.Count; i > 0; i--)
    {
        if (formsList[i].Name != "Menu")
        {
            formsList[i].Close();
        }
    }
