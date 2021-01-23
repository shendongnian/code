     var objRD = objBS.Articles.Where(c => c.RegistratinID.Equals(getID));
    
            if (objRD.Count() > 0)
            {
                foreach (ReportingData objR in objRD)
                {
                    objR.firstname = profile.firstname;
                    objR.lastname = profile.lastname;
    
                }
            }
            objBS.SaveChanges();
