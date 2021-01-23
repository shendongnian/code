    public class frm_Base : Form
    {
      public void frm_Base()
      {
        this.Load += new System.EventHandler(this.frm_Base_Load);
      }
      public void frm_Base_Load(object sender, EventArgs e)
      {
        OnFormLoad();
      }
      public virtual OnFormLoad()
      {
        MessageBox.Show("Hello World");
      }
    }
    public class frm_Derived : frm_Base
    {
      public override OnFormLoad()
      {
        base.OnFormLoad();
        MessageBox.Show("Another Hello From Derived");
      }
    }
