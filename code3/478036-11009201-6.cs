    //Initialize our sets
            var employees = new [] { "Adam", "Bob" };
            var jobs = new[] {  "1", "2", "3" };
            
            //iterate to max number of partitions (Sum)
            for (int i = 1; i <= Math.Min(employees.Length, jobs.Length); i++)
            {
                Debug.WriteLine("Partition to " + i + " parts:");
                //Get all possible partitions of set "employees" (Stirling Set)
                var aparts = employees.AllPartitions().Where(y => y.Count == i);
                //Get all possible partitions of set "jobs" (Stirling Set)
                var bparts = jobs.AllPartitions().Where(y => y.Count == i);
                
                //Get cartesian product of all partitions 
                var partsProduct = from employeesPartition in aparts
                          from jobsPartition in bparts
                                   select new {  employeesPartition,  jobsPartition };
          
                var idx = 0;
                //for every product of partitions
                foreach (var productItem in partsProduct)
                {
                    //loop through the permutations of jobPartition (N!)
                    foreach (var permutationOfJobs in productItem.jobsPartition.Permute())
                    {
                        Debug.WriteLine("Combination: "+ ++idx);
                        for (int j = 0; j < i; j++)
                        {
                            Debug.WriteLine(productItem.employeesPartition[j].ToArrayString() + " : " + permutationOfJobs.ToArray()[j].ToArrayString());
                        }
                    }
                }
            }
