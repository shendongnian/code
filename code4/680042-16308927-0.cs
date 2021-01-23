    public class TrainingPlan
    {
        public int WorkgroupId { get; set; }
        public int AreaId { get; set; }
    
        public TrainingPlan(int workGroupId, int areaId)
        {
            WorkgroupId = workGroupId;
            AreaId = areaId;
        }    
    }
    
    public class TrainingPlanComparer : IEqualityComparer<TrainingPlan>
    {
        public bool Equals(TrainingPlan x, TrainingPlan y)
        {
            //Check whether the compared objects reference the same data. 
            if (x.WorkgroupId == y.WorkgroupId && x.AreaId == y.AreaId) 
                return true;
            
            return false;                        
        }
    
        public int GetHashCode(TrainingPlan trainingPlan)
        {            
            if (ReferenceEquals(trainingPlan, null)) 
                return 0;
            
            int wgHash = trainingPlan.WorkgroupId.GetHashCode();
            int aHash = trainingPlan.AreaId.GetHashCode();
            
            return wgHash ^ aHash;
        }
    }
    
    
    internal class Class1
    {
        private static void Main()
        {
            var plans = new List<TrainingPlan>
                {
                    new TrainingPlan(1, 2),
                    new TrainingPlan(1, 3),
                    new TrainingPlan(2, 1),
                    new TrainingPlan(2, 2)
                };
            var filter = new List<TrainingPlan>
                {
                    new TrainingPlan(1, 2),
                    new TrainingPlan(1, 3),
                };
            Stopwatch resultTimer1 = new Stopwatch();
            resultTimer1.Start();
            var results = plans.Where(plan => filter.Contains(plan, new TrainingPlanComparer())).ToList();
            resultTimer1.Stop();
            Console.WriteLine("Elapsed Time for filtered result {0}", resultTimer1.Elapsed);
            Console.WriteLine("Result count: {0}",results.Count());
            foreach (var item in results)
            {
                Console.WriteLine("WorkGroup: {0}, Area: {1}",item.WorkgroupId, item.AreaId);
            }
            resultTimer1.Reset();
            resultTimer1.Start();
            var result1 = plans.Where(p => p.AreaId == filter[0].AreaId && p.WorkgroupId == filter[0].WorkgroupId).ToList();
            var result2 = plans.Where(p => p.AreaId == filter[1].AreaId && p.WorkgroupId == filter[1].WorkgroupId).ToList();
            resultTimer1.Stop();
            Console.WriteLine("Elapsed time for single query result: {0}",resultTimer1.Elapsed);//single query is faster
            Console.ReadLine();
        }
    }
