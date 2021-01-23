    private Form2 _form2;
    
    public void btnShow_Click(object sender, EventArgs e)
    {
       if(_form2 == null)
         _form2 = new Form2();
      _form2.Show();
    }
    
    public void btnHide_Click(object sender, EventArgs e)
    {
       if(_form2 != null)
         _form2.Hide();
    }
