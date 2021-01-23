    private StateBag PreviousPageViewState
    {
        get
        {
            StateBag returnValue = null;
            if (PreviousPage != null)
            {
                Object objPreviousPage = (Object)PreviousPage;
                MethodInfo objMethod = objPreviousPage.GetType().GetMethod
                        ("ReturnViewState");
                return (StateBag)objMethod.Invoke(objPreviousPage, null);
            }
            return returnValue;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null)
        {
            if (PreviousPageViewState != null)
            {
                var text = PreviousPageViewState["test"].ToString();
            }
        }
    }
