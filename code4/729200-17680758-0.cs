    public interface IUpdateData
    {
      void UpdateData();
    }
    
    public class Form1 : Form, IUpdateData {...}
    public class Form3 : Form, IUpdateData {...}
    
    public class Form2 : Form
    {
      private IUpdateData _parentForm;
      public Form2(IUpdateData _parentForm){...}
      private void btnDelete_Click(object sender, EventArgs e)
      {
        _parentForm.UpdateData();
      }
    }
