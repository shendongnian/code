    public class GantDataRepository
    {
        GantEntities dbContext = new GantEntities();
        GanttModels returnModels = new GanttModels();
        public GantDataRepository()
        {
            foreach (var item in dbContext.WorkPlans)
            {
                returnModels.AllGantt.Add(new GanttModel 
                {
                    ProjectName = item.Product,
                    Rescource = item.ResourcesSets
                });
            }
        }
