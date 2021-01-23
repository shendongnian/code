    string userDate = ""
    if (ddl.SelectedIndex>0)
    { //then you can try to validate date as
    try
    {
    string temp=ydl.SelectedItem.ToString()+"-"+ydl.SelectedItem.ToString();
    temp += " "+ydl.SelectedItem.ToString()
    DateTime dt=Convert.ToDateTime(temp);
    userDate=dt.ToString("yyyy-MM-dd");
    }
    catch
    {
    //Display message on some label that chosen date is invalid
    return;
    }
    }
    else
    {
    userDate=ydl.SelectedItem.ToString();
    if (mdl.SelectedIndex>0)
    {
    userDate += mdl.SelectedItem.ToString();
    }
    }
