    function void SaveRow(Table.RowObject object) {
      var original=null;
      using (context= new DataContext())
            {
                context.ObjectTrackingEnabled = false;
                original = {query}.Single();
            }
            using(context=new DataContext()){
                try
                {
                    context.Table.Attach(object, original);
                    context.SubmitChanges();
                }
                catch (Exception exception) {
                    saveStatus = false;
                
                }
            }
