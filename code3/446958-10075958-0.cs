    public class User {
        public dynamic Data = new ExpandoObject();
    }
    ...
    var user = new User();
    user.Data.SomethingNew1 = "foo";
