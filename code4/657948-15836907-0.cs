    public interface IClosingParent
    {
        void Close();
    }
    
    public class PageA : System.Web.Page, IClosingParent
    {
        public void IClosingParent.Close()
        {
            //Code to close it or hide it
        }
    }
    public class PageB : System.Web.Page, ClosingParent
    {
        public void IClosingParent.Close()
        {
            ((IClosingParent)this.Parent).Close();
            //Code to close it or hide it
        }
    }
    public class PageC : System.Web.Page
    {        
        protected void ButtonClose_Click(object sender, EventArgs e)
        {
            ((IClosingParent)this.Parent).Close();
            
            //Code to close it or hide it     
        }
    }
