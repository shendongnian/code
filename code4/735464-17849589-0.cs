    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebApplication3
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            protected override void CreateChildControls()
            {
                base.CreateChildControls();
                this.CreateRadioButtons();
            }
            private void CreateRadioButtons()
            {
                var tblStars = new Table();
                tblStars.ID = "tblStars";
                ListItem opt1 = new ListItem();
                opt1.Text = "I like red";
                opt1.Value = "Red";
            
                ListItem opt2 = new ListItem();
                opt2.Text = "I like green";
                opt2.Value = "Green";
            
                ListItem opt3 = new ListItem();
                opt3.Text = "I like blue";
                opt3.Value = "Blue";
                var rb = new RadioButtonList();
                rb.ID = "RBQuestion_1";
                rb.Items.Add(opt1);
                rb.Items.Add(opt2);
                rb.Items.Add(opt3);
                var tc = new TableCell();
                var tr = new TableRow();
                tc.Controls.Add(rb);
                tr.Cells.Add(tc);
                tblStars.Rows.Add(tr);
                form1.Controls.Add(tblStars);
            }
            protected void btnSave_Click(object sender, EventArgs e)
            {
                var tblStars = this.form1.FindControl("tblStars") as Table;
                if (tblStars == null)
                    return;
                foreach (TableRow row in tblStars.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        var rb = cell.FindControl("RBQuestion_1") as RadioButtonList;
                        if (rb == null)
                            continue;
                        var selectedValue = rb.SelectedValue;
                    }
                }
            }
        }
    }
