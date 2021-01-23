    public partial class Form1 : Form
    {
      
      public void RegisterSon()
      {
         ChildForm frm = new ChildForm();
         frm.MyEventChild += new MyEvntHndler(frm_MyEventChild);
      }
      void frm_MyEventChild(string data)
      {
         
      }
    }
    public delegate void MyEvntHndler(string data);
    public class ChildForm: Form
    {
      public event MyEvntHndler MyEventChild;
      private void button1_Clicked(object sender, EventArgs e)
      {
         if (MyEventChild != null)
         {
            MyEventChild("This is my data");
         }
      }
    }
