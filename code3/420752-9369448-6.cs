    public abstract class AbstractGroup {
        public string Name { get; set; }
        public AbstractGroup(string name) { this.Name = name; }
    }
    public class Group : AbstractGroup {
        public Group(string name) : base(name) {}
    }
    public class SubGroup : AbstractGroup {
        public SubGroup(string name) : base(name) {}
    } 
