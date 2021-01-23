    public abstract class MyObjectBase
    {
        public abstract void Begin();
    }
    public class OneOfMyObjects : MyObjectBase
    {
        public override void Begin()
        {
            //do stuff
        }
    }
    public class ManagmentClass
    {
        public MyObjectBase myCurrentObject;
        //called a only one when the program starts
        public void Start()
        {
            Mymethod(new OneOfMyObjects());
        }
        //generic method 
        public void Mymethod<T>(T Objectclass) where T : MyObjectBase {
        MyObjectBase myObject = Objectclass;
        myObject.Begin(); // Shouldn't throw an error any more
        myObject.GetType().ToString(); //returns "OneOfMyObjects" 
        }
    }
