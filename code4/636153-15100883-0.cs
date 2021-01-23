    public class Form1
    {
        //Form1 stuff
        //Delegate stuff for performing on UI thread.
        private delegate void IntDelegate(int index);
        private void RemoveTabByIndexOnUi(int index)
        {
            tabControl1.TabPages.RemoveAt(index);
        }
        //internal method that will be accessible to other members of this namespace.
        internal void RemoveTabByIndex(int i)
        {
            //Do this action on UI delegate.
            this.Invoke(new IntDelegate(RemoveTabByIndexOnUi), i);
        }
    }
    public class Form2
    {
        public Form2()
        {
           Form1 frm = new Form1();
           frm.Show();
           frm.RemoveTabByIndex(1);
        }
    }
