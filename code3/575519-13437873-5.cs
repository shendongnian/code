    // using this const you avoid bugs in mispelling the correct key.
    const string cJobSeekerNameConst = "JobSeeker_cnst";
    
    public List<JobSeeker> JobSeekersList
    {
        get
        {
            if (!(ViewState[cJobSeekerNameConst] is List<JobSeeker>))
            {
                // need to fix the memory and added to viewstate
                ViewState[cJobSeekerNameConst] = new List<JobSeeker>();
            }
    
            return (List<JobSeeker>)ViewState[cJobSeekerNameConst];
        }
    }
