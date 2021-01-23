    public abstract class ViewModelBase
    {
         //Pull your data from the repository here
         protected abstract void RefreshCore();
         public void Refresh()
         {
                RefreshCore();
                IsDirty = false;
         }
    
         private bool _isVisible = false;
         //DataBind this to the visibility of element "hosting" your view model
         public bool IsVisible
         {
             get { return _isVisible; }
             set
             {
                  if (_isVisible == value)
                      return;
    
    
                  _isVisible = value;
                  if (IsVisible && IsDirty)
                       Refresh();
             }
         }
    
         private bool _isDirty = true;
         public bool IsDirty 
         {
             get { return _isDirty; }
             set 
             {
                if (_isDirty == value)
                   return;
    
                _isDirty = value;
                if (IsVisible && IsDirty)
                   Refresh();
             }
         }
         
    }
