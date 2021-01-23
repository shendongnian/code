    public static void FindPage(Control mp)
    {
        var masterPage = mp as MyMasterPage;
        if (mp != null)
        {
            mp.BodyTag.Attributes.Add("class", "NewStyle");
        }
    }
