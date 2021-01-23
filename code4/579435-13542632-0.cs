    public partial class Form2: Form
    {
    public string checkBoxSelected = "";
    }
     
    
    public partial class Form1 : Form
    {
    private void MakeResult()
    {
    Form2 result = new Form2();
    result.checkBoxSelected = "+";
    result.Show();
    }
    }
