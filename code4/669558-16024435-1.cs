    public MvcHtmlString TextNotIncluded
    {
        get
        {
            return MvcHtmlString.Create("which is <u>not</u> included in the Quote");
        }
    }
