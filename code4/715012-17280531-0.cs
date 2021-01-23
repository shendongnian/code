    public class Customer : Entity, IBindableComponent {
         //Your code
         //Members of IBindableComponent
         ISite iSite;
         ControlBindingsCollection dataBindings;
         BindingContext bindingContext = new BindingContext();
         public Customer(){
             dataBindings = new ControlBindingsCollection(this);
         }
         public event EventHandler Disposed;
         public void Dispose(){
             //your code for disposing
         }
         public BindingContext BindingContext {
            get { return bindingContext;}
            set {bindingContext = value;}
         }
         public ControlBindingsCollection DataBindings {
            get { return dataBindings;}
         }
         public ISite Site {
            get { return iSite;}
            set {iSite = value;}
         }
    }
