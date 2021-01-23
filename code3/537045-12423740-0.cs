    public class VisibilityBinding : MultiBinding, IMultiValueConverter
    {
       public VisibilityBinding()
       {
          var isSomething = new Binding("IsSomething");
          isSomething.ElementName = myUsrCtrl;
          this.Bindings.Add(isSomething);
    
          //Add more bindings
          
          this.Converter = this;
        }
        
        //Implement IMultiValueConverter to compute a System.Visibility from the bound values.
    }
