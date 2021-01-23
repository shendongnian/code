    protected void Button1_Click
    (object sender, EventArgs e)
    {
         BookSupplier1.WebService1 supplier1 = new BookSupplier1.WebService1();
    
         supplier1.GetCostCompleted += new BookSupplier1.GetCostCompletedEventHandler(supplier1_GetCostCompleted);
    
         supplier1.GetCostAsync(TextBox1.Text, BulletedList1);
    
    }
    void supplier1_GetCostCompleted(object sender, BookSupplier1.GetCostCompletedEventArgs e)
    {
         if (e.Error != null)
         {
             throw e.Error;
         }
         BulletedList list = (BulletedList)e.UserState;
         list.Items.Add("Quote from BookSupplier1 : " + e.Result.ToString("C"));
    }
