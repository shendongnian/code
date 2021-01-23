        var sqtmDC = new SqtmLinqDataContext();
            var mainTable = from generalInfo in sqtmDC.GetTable<General_Info>()
                          //join quoteData in sqtmDataContext.GetTable<Quote_Data>() on generalInfo.Quote_ID equals quoteData.Quote_ID
                          select generalInfo;
           
                          myGrid.ItemsSource = mainTable;
        }
         private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            var sqtmDC = new SqtmLinqDataContext();
           
           // string theDate = System.DateTime.Today.Date.ToString("d");
            int quantity = Convert.ToInt32(quantityTxt.Text);
            
            General_Info insert = new General_Info();
            insert.Open_Quote = DateTime.UtcNow;
            insert.Customer_Name = customerNameTxt.Text;
            insert.OEM_Name = oemNameTxt.Text;
            insert.Qty = quantity;
            insert.Quote_Num = quoteNumberTxt.Text;
            insert.Fab_Drawing_Num = fabDrawingNumTxt.Text;
            insert.Rfq_Num = rfqNumberTxt.Text;
            insert.Rev_Num = revNumberTxt.Text;
            sqtmDC.General_Infos.InsertOnSubmit(insert);
            sqtmDC.SubmitChanges();
            int quoteID = insert.Quote_ID;
            var mainTable = from generalInfo in sqtmDC.GetTable<General_Info>()
                            select generalInfo;
            myGrid.ItemsSource = mainTable;
        
