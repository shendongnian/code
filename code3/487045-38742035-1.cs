    public SurveyDataContext() :
                base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MikesConnectionString"].ConnectionString, mappingSource)
    {
         OnCreated();
    }
