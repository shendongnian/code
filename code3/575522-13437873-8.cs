    // using this const you avoid bugs in mispelling the correct key.
    const string cJobSeekerNameConst = "JobSeeker_cnst";
    
    public List<JobSeeker> JobSeekersList
    {
        get
        {
            // check if not exist to make new (normally before the post back)
            // and at the same time check that you did not use the same viewstate for other object
            if (!(ViewState[cJobSeekerNameConst] is List<JobSeeker>))
            {
                // need to fix the memory and added to viewstate
                ViewState[cJobSeekerNameConst] = new List<JobSeeker>();
            }
    
            return (List<JobSeeker>)ViewState[cJobSeekerNameConst];
        }
    }
