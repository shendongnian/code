    public class Manipulator{
        class UserDefined{
          private int data;
          public int getData(){ return data;}
          public void setData(int d) {data = d;}
          public UserDefined(){ d = 0; }
        }
        
        public UserDefined returnUserDefined()
        {
           return new UserDefined();
        }
        
        public void doSomethingWithIt(UserDefined d)
        {
           d.setData(500);
        }
        
        public int getDataWithingUserDefined(UserDefined d)
        {
           return d.getData();
        }
    }
