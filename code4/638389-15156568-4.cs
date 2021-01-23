       public class MyObject {
        ...
        public override int GetHashCode() {
           int result;
           result = ((this.Name != null) ? this.Name.GetHashCode() : 0) ^
                    ((this.Address != null) ? this.Address.GetHashCode() : 0) ^
                    this.Age.GetHashCode();
           // without the syntactically possible but logically challenged:
           // ^ this.TimeWhenIBroughtThisInstanceFromTheDatabase.GetHashCode()
        }
        ...
    } 
