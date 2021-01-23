    public class Objective 
    {
        public int Level { get; set; }
    }
    
    public class CurrentMediumObjectives : Objective
    {
        public ObservableCollection<ChildrenObjective> ChildrenObjective { get; set; }
    }
    
    public class ChildrenObjective : Objective
    {
    }
