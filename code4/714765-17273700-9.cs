     Form2 f = new Form2();
     f.UpdateData += myCallbackUpdateMethod;
     public void myCallbackUpdateMethod()
     {
        DataTable dt = GetTable();
        UpDateData(dt)
     }
