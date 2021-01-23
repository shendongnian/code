    private System.Delegate _delNoParam;
        public Delegate PageMethodWithNoParamRef
        {
            set { _delNoParam = value; }
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            _delNoParam.DynamicInvoke();
        }
