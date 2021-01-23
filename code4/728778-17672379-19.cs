    private TempCalib _tempCalib;
    private void calibBtn_Click(object sender, EventArgs e)
    {
         if (_tempCalib == null)
         {
             _tempCalib = new TempCalib();
             _tempCalib.SomethingMustBeDone += _tempCalib_SomethingMustBeDone;
             
             // In _tempCalib_SomethingMustBeDone you'll invoke proper member
             // and possibly hide _tempCalib (remove it from OkButton_Click)
         }
         _tempCalib.Show();
    }
