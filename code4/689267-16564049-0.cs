    public abstract class Parent : IComparable<Parent>, IComparable {
        public string Title;
        public Parent(string title){this.Title = title;}
    
        int IComparable.CompareTo(object other) {
            return CompareTo((Parent)other);
        }
        public int CompareTo(Parent other){
            return this.Title.CompareTo(other.Title);
        }
    }
