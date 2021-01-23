    private TempCalib _tempCalib;
    private void calibBtn_Click(object sender, EventArgs e)
    {
         if (_tempCalib == null)
             _tempCalib = new TempCalib(this);
         _tempCalib.Show();
    }
