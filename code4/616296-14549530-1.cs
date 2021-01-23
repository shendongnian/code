    public abstract class ModelBase
    {
        public UserNavigationModel NavigationModel { get; set; }
    }
    
    public class ModelForView1 : ModelBase { ... }
    public class ModelForView2 : ModelBase { ... }
    public class ModelForView3 : ModelBase { ... }
