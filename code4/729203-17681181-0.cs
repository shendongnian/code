    //Declare public delegate
    public delegate void CustomFormEvent(object sender);
    // Create a base class 
    public partial  class BaseUpdateForm : Form
    {
    public event CustomFormEvent UpdateData; // Event declaration
    protected void CustomFormEventHandler() 
    {
        if (this.UpdateData != null)
            UpdateData(this);
    }
    }
