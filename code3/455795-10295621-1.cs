    public int GetCreditObjectPosition(CreditObject x, List<int> jobList) {
        var jobDictionary = 
            jobList.Select((job, index) => new { Job = job, Index = Index } )
                   .ToDictionary(item => item.Job, item => item.Index);
        int position;
        if(!jobDictionary.TryGetValue(x.Job, out position) {
            throw new Exception("Job not within List");
        }
        return position;
    }
    
