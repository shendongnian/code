     public IEnumerable<MyClass> GetApplicant()
        {
            IEnumerable<MyClass> applicantdata = Cache.Get("applicants") as IEnumerable<APPLICANT>;
            IEnumerable<Profile> profiledata = Cache.Get("profiles") as IEnumerable<Profile>;
    
    
            if (applicantdata == null)
            {
    
                var applicantList = (from a in context.Profiles 
                                     join app in context.APPLICANTs
                                     on a.PROFILE_ID equals app.Profile_id into joined
                                     from j in joined.DefaultIfEmpty()
                                     select new MyClass //Change here
                                                {
                                                   APPLICANT = j, 
                                                   Profile = a,
                                                }).Take(1000);
    
                       applicantdata = applicantList.AsEnumerable();
                     
    
    
                if (applicantdata.Any())
                {
                    Cache.Set("applicants", applicantdata, 30);
                }
            }
            return applicantdata;
    
        }
