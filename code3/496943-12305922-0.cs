       public  void ItemClicked(object sender,AdapterView.ItemClickEventArgs args)
        {
            try
    
                  {
                   
                   string fname = ((TextView)args.View).Text;
                  // do something with clicked item text
                  }
            catch (Exception)
            {
                throw;
            }
        }
