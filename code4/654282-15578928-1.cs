    public class MyViewController : UIViewController
    {
        public MyViewController ()
        {
        }
        
        public void Foo()
        {
            FaceBookSingleton.Instance.DoSomeAction();
            FaceBookSingleton.Instance.Something = 4;
        }
    }
