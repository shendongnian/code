    Public Class Form1
    {
    Form frm2;
    
    //Show form here
    protected void Button1_Clik
    {
    frm2=new Form2();
    frm2.Show();
    }
    
    //Even the form is hidden, you may show the same instance /same state of form again 
    protected void Button2_Click()
    {
    frm2.Show();
    }
    
    
    }
