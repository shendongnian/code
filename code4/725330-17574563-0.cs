    private Button _lastButtonSelected = null;
    protected void btyDynamic(object sender, EventArgs e)
    {
       // Set new button back color
       Button btn = sender as Button;
       if(btn != null)
       {
          btn.BackColor = Color.LightSteelBlue;
       }
       // Reset last button color
       if(_lastButtonSelected != null)
       {
          _lastButtonSelected.BackColor = ...; // Put default back color here
       }
       _lastButtonSelected = btn;
    }
