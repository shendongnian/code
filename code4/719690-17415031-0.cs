            public string GetHighestPaidProfession()
            {
                //string highestPaidProfession = ""; no need for the string variable.
    
                //Gets all the salaryInformation objects and stores them in a list
                //just added this elements to list for demonstration only.
                List<SalaryInformation> allSalaries = new List<SalaryInformation>()
                {
                    new SalaryInformation("doctor",2010,500.00m,585.00m),
                    new SalaryInformation("doctor",2010,500.00m,585.00m),
                    new SalaryInformation("doctor",2010,500.00m,550.00m),
                    new SalaryInformation("doctor",2010,500.00m,550.00m),
                    new SalaryInformation("manager",2010,400.00m,510.00m),
                    new SalaryInformation("manager",2010,400.00m,490.00m),
                    new SalaryInformation("manager",2010,400.00m,500.00m),
                    new SalaryInformation("manager",2010,400.00m,480.00m),
                    new SalaryInformation("director",2010,600.00m,625.00m),
                    new SalaryInformation("director",2010,600.00m,615.00m)
                };
                
                Dictionary<string,List<decimal>> results = new Dictionary<string,List<decimal>>();
    
                foreach(SalaryInformation si in allSalaries)
                {
                    if(results.ContainsKey(si.Profession))
                    {
                        results[si.Profession].Add(si.CurrentSalary);
                    }
                    else
                    {
                        results.Add(si.Profession,new List<decimal>(){si.CurrentSalary});
                    }
                }
    
                //this will result in dictionary<string,decimal>,where the dedimal will
                //already be the average of all salary of each profession.
                var result = results.ToDictionary(k => k.Key, v => v.Value.Sum() / v.Value.Count);
    
                //returns the string in result dictionary which points to the
                //highest value.
                return result.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            }
