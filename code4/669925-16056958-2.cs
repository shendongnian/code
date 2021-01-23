    public class AdminClusterCreateModel : BaseViewModelAdmin
    {
        public Cluster Item {get; set;}
        public AdminClusterCreateModel()
        {
            Item = new Cluster();
        }
     }
