    public class TestPresenter
    {
       private ITestView view;
    
       public TestPresenter(ITestView view)
       {  
           this.view = view;
           view.Load += View_Load;
       } 
       private void View_Load(object sender, EventArgs e)
       {
           var data = // get from model
           view.LoadList(data);
       }
    }
