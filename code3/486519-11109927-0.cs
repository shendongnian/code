    for(int i=0; i < 10; i++)
    {
        string chk_name = "chk_" + i.ToString();
        if (Request.Form[chk_name] != null)
        {
            //checkbox is checked
        }
        else
        {
            //checkbox is not checked
        }
    }
