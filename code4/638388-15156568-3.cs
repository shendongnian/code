    public class MyObject {
        ...
        public override bool Equals(object obj) {
            if (obj is MyObject) {
                var that = obj as MyObject;
                return (this.Name == that.Name) && 
                       (this.Address == that.Address) &&
                       (this.Age == that.Age);
                       // without the syntactically possible but logically challenged:
                       // && (this.TimeWhenIBroughtThisInstanceFromTheDatabase == 
                       //     that.TimeWhenIBroughtThisInstanceFromTheDatabase)
            } else 
                return false;
        }
        ...
    }
