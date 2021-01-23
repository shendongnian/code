    public class Form1 : Form
    {
        //Delegate stuff for performing on UI thread.
        private delegate void TabPageDelegate(TabPage tab);
        private void RemoveTabOnUi(TabPage tab)
        {
            tabControl1.TabPages.RemoveAt(tab);
        }
        //internal method that will be accessible to other members of this namespace.
        internal void RemoveTab(TabPage tab)
        {
            //Do this action on UI delegate.
            this.Invoke(new TabPageDelegate(RemoveTabOnUi), tab);
        }
        //... Form1 Stuff
    }
    public class Form2 : Form
    {
        public Form2()
        {
           //Add event to the closing event handler
           this.Closing += OnClosing;
        }
        private void OnClosing(object sender, EventArgs e)
        {
           //Check to make sure that MdiParent and Parent are correct
           if(null != this.MdiParent && this.MdiParent is Form1 && 
                  null != this.Parent && this.Parent is TabPage)
           {
               //Calls the Form1().RemoveTab() internal method 
               ((Form1)this.MdiParent).RemoveTab((TabPage)this.Parent);
           }
        }
    
        //... Form2 Stuff
    }
