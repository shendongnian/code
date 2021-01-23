        public void ReturnHire(string carregistration, string hirefromdate, string hiretodate) 
        { 
            var result = customermembers.Where(c => c.CustomerCarType.Any(n => String.Equals(n.CarRegistration, carregistration));
            foreach (var item in result)
            { 
                item.CustomerHireDate.RemoveAll(cs => cs.HireFromDate == hirefromdate && cs.HireToDate == hiretodate); 
                item.CustomerCarType.RemoveAll(cs => cs.CarRegistration == carregistration); 
            } 
        } 
