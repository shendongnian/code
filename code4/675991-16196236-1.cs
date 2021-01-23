    public class MyEntity
    {
        public int MyEntityId { get; set;}
        public int MyNavigationPropertyID { get; set;}
        public MNP MyNavigationProperty { get; set; }
    }
    
    public class MNP
    {
        public int MNPID { get; set;}
    }
