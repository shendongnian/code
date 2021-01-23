    public class MyNewClass
    {
    	Form1 _form;
    
    	public MyNewClass(Form1 form)
    	{
    		_form = form;
    	}
    
    	public void ClearTextBoxes()
    	{
    		_form.txtFirstName.Clear();
    		//Clear the rest
    	}
    }
