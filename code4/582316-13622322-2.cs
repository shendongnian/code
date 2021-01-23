    public class Presenter1
    {
        IView1 _view1;
        IView2 _view2;
    
        public Presenter1(IView1 view1, IView2 view2)
        {
            _view1 = view1;
            _view2 = view2;
    
            _view1.OnSave += OnSave;
            _view1.OnSomeEvent += OnSomeEvent;
            _view2.OnFoo += OnFoo;
        }
    
        public void OnSave()
        {
            var data1 = _view1.GetData();
            var data2 = _view2.GetData();
            // update model
            ...
        }
    
        public void OnSomeEvent()
        {
           // inform view2 about it
           _view2.DoOnSomeEvent();
        }
    
        ...
    }
    
    public partial class MyPage : Page, IView1
    {
       public void Page_Load(...)
       {
         //do wire up
         _presenter = new Presenter(this, usercontrol1);
       }
       ...
    }
