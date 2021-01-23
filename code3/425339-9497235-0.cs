    class YourViewModel
    {
       public void SelectItem(object o)
       {       }
       
       private ICommand selectedItemCommand
       public ICommand SelectedItemCommand 
       {
         get
         {
            if(selectedItemCommand == null)
            { 
              // RelayCommand will point to SelectItem() once mouse is clicked
              selectedItemCommand = new RelayCommand(SelectItem);
            }
            return selectedItemCommand;
         } 
       }
    }
