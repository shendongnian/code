        protected void FormView1_PreRender(object sender, EventArgs e)
        {
            if (hfEditAllowed.Value == "false")
            {
                Control lb_n = FormView1.FindControl("LinkButton_New");
                lb_n.Visible = false;
                Control lb_e = FormView1.FindControl("LinkButton_Edit");
                lb_e.Visible = false;
                Control lb_d = FormView1.FindControl("LinkButton_Delete");
                lb_d.Visible = false;
            }
        }
