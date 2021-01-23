    Form2 _form2 = null;
    
    void Button1_Click(object sender, EventArgs e) 
    {    
         if (_form2 == null)
         {
             _form2 = new Form2();  
             _form2.Closed += Form2_Closed;
         } 
    
         _form2.Show();
         _form2.BringToFront(); 
     }
    private void Form2_Closed(object sender, System.EventArgs e)
    {
    	_form2 = null;
    }
