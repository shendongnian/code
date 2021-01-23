         MyType master = this.Master as MyType;
         if(master == null)
            return;
       
         master.MyProperty = "something";
         // In master page
         public string MyProperty
         {
            get { return label.Text; }
            set { label.Text = value; }
         }
