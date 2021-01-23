    private IList<JobSeeker> JobSeekersList
    {
        get
        {
            var list = ViewState["key"] as List<JobSeeker>;
            if (list == null)
            {
                // handling logic goes here
            }
            return list;
        }
        set
        {
            ViewState["key"] = value;
        }
    }
