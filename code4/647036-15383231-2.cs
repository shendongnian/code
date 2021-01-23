    public class frmInkomsteBlad : Form, ICustomForm{
      public string Title{
        get{
         return this.Text;
        }
        set{
         this.Text = value;
        }
      }
      //other implementation here
    }
