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
           List<AppSignature> signatures = // get from model
           List<AppSignatureDto> signatureDtos = // map domain class to dto
           view.LoadList(signatureDtos);
       }
    }
