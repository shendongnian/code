    public class Test {
       public string var_;//I'm a public field, I'll be returned
       private int id_; //I'm a private field, you'll have to do more to get me
       public int Id {get { return id_;} set {id_=value;}} //I'm a property, I don't feel concerned
    }
