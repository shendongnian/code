    public static class ApplicationList
    {
        private static List<ApplicationsModel> appmodel = new List<ApplicationsModel>();
        public static List<ApplicationsModel> ApplicationsModels 
        { 
           get { return appmodel ;}
        }
        //DON'T THINK YOU NEED A SET IN THIS CASE.. 
        // BUT ADD IT, IF NEED
    }
