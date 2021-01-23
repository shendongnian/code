    class ParentForm
    {
        public int MyVariable
        {
            return 1;
        }
    }
    
    class ChildForm
    {
        public void MyMethod()
        {
            var parent = this.MdiParent as ParentForm;
            foo = parent.MyVariable;
        }
    }
