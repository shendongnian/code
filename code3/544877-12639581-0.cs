    public class Object1
    {
        public int id;
        public DateTime time;
    }
    List<Object1> list1 = new List<Object1>() 
    {
        new Object1(){id=1,time=new DateTime(1991,1,1)},
        new Object1(){id=2,time=new DateTime(1992,1,1)}
    };
    List<Object1> list2 = new List<Object1>() 
    {
        new Object1(){id=1,time=new DateTime(2001,1,1)},
        new Object1(){id=3,time=new DateTime(1993,1,1)}
    };
