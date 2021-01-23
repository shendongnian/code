    public static List<ApplicationsModel> ApplicationsModels 
    { 
        get { return _applicationsModels; }
        private set { _applicationModels = value; } // Do you really want a set?
    }
    private static List<ApplicationsModel> _applicationsModels = new List<ApplicationsModel>();
