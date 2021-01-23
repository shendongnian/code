    public class test1 : CompositeControl
    {
        protected Button btn_submit1;
        protected Button btn_submit2;
    
        private bool Submit2Created
        {
            get { return (bool) (ViewState["Submit2Created"] ?? false); }
            set { ViewState["Submit2Created"] = value; }
        }
    
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        protected override void CreateChildControls()
        {
            btn_submit1 = new Button();
            btn_submit1.Text = "Click me1!";
            btn_submit1.Click += btn_submit1_Click;
            this.Controls.Add(btn_submit1);
    
            // Button 2 is created previously, 
            // so we need to load it back.
            if (Submit2Created)
            {
                AddSubmit2();
            }
    
            this.ChildControlsCreated = true;
        }
    
        protected void btn_submit1_Click(object sender, EventArgs e)
        {
            if (!Submit2Created)
            {
                AddSubmit2();
                Submit2Created = true;
            }
        }
    
        protected void btn_submit2_Click(object sender, EventArgs e)
        {
            Label lbl_done = new Label();
            lbl_done.Text = "Thank you :)";
            this.Controls.Add(lbl_done);
        }
    
        private void AddSubmit2()
        {
            var btn_submit2 = new Button();
            btn_submit2.Text = "Click me2!";
            btn_submit2.Click += btn_submit2_Click;
            this.Controls.Add(btn_submit2);
        }
    }
