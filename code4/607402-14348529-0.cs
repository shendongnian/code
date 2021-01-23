    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            if (this.Control is MyUserControl)  // replace this with your usercontrol type
            {
                // cast this.Control to you type of usercontrol to get at it's
                // controls easier
                var i = this.Control as MyUserControl; // replace ***
                this.EnableDesignMode(i.label1, "unique_name1");
                this.EnableDesignMode(i.pictureBox1, "unique_name2");
            }
        }
