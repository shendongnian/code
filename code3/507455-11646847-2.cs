    private void button_click(object sender, eventArgs e)
    {
         FormB.ActiveForm.Disposed+= new EventHandler(CloseFormB)
    }
    
    private void CloseFormB(object sender, eventArgs e)
    {
          FormB.ActiveForm.Dispose();
    }
