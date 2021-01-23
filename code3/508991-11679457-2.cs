        public void ReturnHire(string carregistration, string hirefromdate, string hiretodate) 
        { 
            if (customermembers.Any(c => c.CustomerCarType.Any(n => String.Equals(n.CarRegistration, carregistration)))
            { 
                customermembers.ForEach(c => c.CustomerHireDate.RemoveAll(cs => cs.HireFromDate == hirefromdate && cs.HireToDate == hiretodate)); 
                customermembers.ForEach(c => c.CustomerCarType.RemoveAll(cs => cs.CarRegistration == carregistration)); 
            } 
        } 
