namespace MyNameSpace
{
 public partial class Form1 : Form
 {
  public Form1()
  {
   InitializeComponent();
  }
  private void Form1_Load(object sender, EventArgs e)
  {
   txtSchedNum.Enter += new EventHandler(txtSchedNum_Enter);
  }
  protected void txtSchedNum_Enter(Object sender, EventArgs e)
  {
   txtSchedNum.Text = "";
  }
 }
}
