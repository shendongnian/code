    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    
    namespace BindingListSample
    {
        public partial class _Default : System.Web.UI.Page
        {
            static List<Employee> bindingL = new List<Employee>();
            protected void Btn_Click(object sender, EventArgs e)
            {
                bindingL.Add(new Employee { Name = TxtName.Text });
                GrvSample.DataSource = bindingL;
                GrvSample.DataBind();
            }
        }
        public class Employee
        {
            public string Name { get; set; }
        }
    }
