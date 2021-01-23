    FormB formB = new FormB(this);
    ...
    class FormB
    {
        private FormA parent;
        internal FormB(FormA parent)
        {
            this.parent = parent;
        }
        public void SomeOtherMethod()
        {
            // Or parent.Id as it would normally be, as a property...
            string id = parent.getID(); 
        }
    }
