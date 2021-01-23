    using System;
    
    public partial class WebUserControl : System.Web.UI.UserControl
    {
        private string _myProperty;
        public string MyProperty 
        {
            get { return this._myProperty; }
            set { this._myProperty = value; }
        }
    
        public bool IsChecked
        {
            get 
            {
                return this.MyCheckBox.Checked;
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
