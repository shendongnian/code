    IView1 : IView2 { }
    
    public class Presenter1
    {
       IView1 _view1;
        
       public Presenter1(IView1 view1)
       {
           _view1 = view1;
        
           _view1.OnSave += OnSave;
           _view1.OnSomeEvent += OnSomeEvent;
           _view1.OnFoo += OnFoo;
       }
       ...
    }
    
    public partial class MyPage : Page, IView1
    {
           public void Page_Load(...)
           {
             //do wire up
             _presenter = new Presenter(this);
    
             // handle user control events
             UserControl1.Foo += UserControl1_OnFoo();
             UserControl1.XyzEvent += UserControl1_XyzEvent();
    
           }
           ...
    
           private void UserControl1_OnFoo(...)
           {
              // bubble up to presenter
              OnFoo(..)
           }
    
           private void UserControl1_XyzEvent(...)
           {
              // private interaction (purely about some UI manipulation), 
              // will not be bubble up to presenter
              ...
           }
    }
