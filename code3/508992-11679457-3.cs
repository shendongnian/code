        public void ReturnHire(string carregistration, string hirefromdate, string hiretodate) 
        { 
            var result = customermembers.Where(c => c.CustomerCarType.Any(n => String.Equals(n.CarRegistration, carregistration));
            foreach (var customermember in result)
            { 
                customermember.CustomerHireDate.RemoveAll(cs => cs.HireFromDate == hirefromdate && cs.HireToDate == hiretodate); 
                customermember.CustomerCarType.RemoveAll(cs => cs.CarRegistration == carregistration); 
            } 
        }
