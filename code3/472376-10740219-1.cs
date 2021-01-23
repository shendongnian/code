            var query = dx.GetAllJobs().Where(x => x.JobName.Contains(keyword));
            if (SecLink != 0)
            {
                query = query.Where(x => x.SectorLink.Equals(SecLink));
            }
            if (LocLink != 0)
            {
                query = query.Where(x => x.LocationLink.Equals(LocLink));
            }
            if (IndLink != 0)
            {
                query = query.Where(x => x.IndustryLink.Equals(IndLink));
            }
            if (VacLink != 0)
            {
                query = query.Where(x => x.VacancyTypeLink.Equals(VacLink));
            }
            var lstJobs = query.ToList();
