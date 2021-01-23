    public class Form1
    {
        //Form1 stuff
        //Delegate stuff for performing on UI thread.
        private delegate void TabPage Delegate(TabPage tab);
        private void RemoveTabOnUi(TabPage tab)
        {
            tabControl1.TabPages.RemoveAt(tab);
        }
        //internal method that will be accessible to other members of this namespace.
        internal void RemoveTab(TabPage tab)
        {
            //Do this action on UI delegate.
            this.Invoke(new IntDelegate(RemoveTabOnUi), tab);
        }
    }
    public class Form2
    {
        public void OnXButton_Pressed(object sender, EventArgs e)
        {
           if(null != this.MdiParent && this.MdiParent is Form1 && 
                  null != this.Parent && this.Parent is TabPage)
           {
               ((Form1)this.MdiParent).RemoveTab((TabPage)this.Parent);
           }
        }
    }
