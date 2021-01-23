    protected void Page_Load(object sender, EventArgs e)
            {
                Languages = GetSiteLanguagesService();
                if (Languages.Count > 1)
                {
    
                    LanguageDropdown = new DropDownList(); //allocate the control
                    LanguageDropdown.Visible = true;
                    LanguageDropdown.DataTextField = "DisplayName";
                    LanguageDropdown.DataValueField = "LangUrl";
                    LanguageDropdown.DataSource = Languages ;
                    LanguageDropdown.DataBind();
                }
            }
