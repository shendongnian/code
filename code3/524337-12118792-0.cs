    [System.ComponentModel.Composition.InheritedExport(typeof(ProblemView))]
    public abstract class ProblemView : UserControl // or whatever your Views inherit
    {
       public abstract Type ViewModelType { get; }
    }
    
    [System.ComponentModel.Composition.InheritedExport(typeof(ProblemViewModel))]
    public abstract class ProblemViewModel : BaseViewModel // or whatever your ViewModels inherit
    {
    }
    
    // in your App class
    {
       [ImportMany(typeof(ProblemView))]
       public ProblemView[] Views { get; set; }
       [ImportMany(typeof(ProblemViewModel))]
       public ProblemViewModel[] ViewModels { get; set; }
    
       void MarryViewViewModels()
       {// called during MEF composition
          foreach (ProblemView view in Views)
          {
             foreach(ProblemViewModel vm in ViewModels)
             {
                if(Equals(view.ViewModelType, vm.GetType())
                {// match -> inject the ViewModel
                   view.DataContext = vm;
                   break;
                }
             }      
          }
       }
    }
    
    // example of usage
    public partial class SomeView : ProblemView
    {
       public override Type ViewModelType { get { return typeof(SomeViewModel); } }
    }
