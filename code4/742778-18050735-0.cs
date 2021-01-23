    public partial class Exam    {
     //....
        [ScriptIgnore]
        public virtual ICollection<Objective> Objectives { get; set; }
    }
