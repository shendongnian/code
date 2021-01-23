    class CAD
    {
        RAT form;
        public CAD(RAT form)
        {
            this.form = form;
            // Now the CAD class maintains a reference to the form it is
            // supposed to change. This field can be used in other methods
            // when it is time to remove the extra controls and restore
            // the size, like so:
            // form.Size = new System.Drawing.Size(805, 300);
        }
    }
