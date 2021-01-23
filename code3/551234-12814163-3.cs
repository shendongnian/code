    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class TimeUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        public string SelectedTime
        {
            get
            {
                string _time = this.hour.SelectedItem.Text + ":" + this.Minute.SelectedItem.Text + " " + this.Seconds.SelectedItem.Text;
                return _time;
            }
        }
    
    }
