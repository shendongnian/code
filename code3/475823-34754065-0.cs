    protected override PageStatePersister PageStatePersister
    {
        get
        {
            if (LoginRedirectUrl == "/the_page_in_question.aspx")
            {
                return new HiddenFieldPageStatePersister(Page);
            }
            return new CustomPageStatePersister(this);
        }
    }
