    private void DeleteRow()
    {
      this.justDeletedRow = true;
      this.bindingSource.DeleteRow(...);
    }
    protected void BindingSource_CurrentChanged(object sender ...)
    {
      if (this.justDeletedRow)
      { 
         this.justDeletedRow = false;
         return;
      }
      // Process changes otherwise..
    }
