    public void ShowData2()
    {
        try
        {
            ServiceReference6.Service1Client obj6 = new ServiceReference6.Service1Client();
            DataTable table = Deserialize<DataTable>(obj6.SelectSavedProcessInformation());
            if(table != null)
            {
               foreach(DataRow row in table.Rows)
               {
                   // fill the listbox
               }
            }
