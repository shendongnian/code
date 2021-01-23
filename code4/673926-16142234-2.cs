    public sealed class DataGridViewColumnSelector  : IDisposable
    {
      //removed: ~DataGridViewColumnSelector  (){ Dispose(false); /*destructor*/ }
      
      //class context omitted
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
      private void Dispose(bool disposing)
      {
        if(disposing)
        {
          //kill the reference - do not dispose the object. 
          //it was *not* created here, os it should *not* be disposed here
          mDataGridView = null; 
                               
          //makes sure no outside object has a reference
          //to the event - thus keeping it alive when it should be garbagecollected
          GridRightClickEvent = null; 
         
          if(mCheckedListBox != null) mCheckedListBox.Dispose();
          if(mPopup != null) mPopup.Dispose();
          if(mControlHost  != null) mControlHost .Dispose();
        }
      }
    }
