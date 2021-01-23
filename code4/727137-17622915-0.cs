    Label lblCat;
        Label lblSubcat;
        TextBox txtCat, txtSubCat;
        protected void lnkCat_Click(object sender, EventArgs e)
        {
            //Panel2.Visible = false;
            //Panel1.Visible = true;
            Label lblCat = new Label();
            lblCat.Text = "Enter new Category: ";
            PHcat.Controls.Add(lblCat);
            txtCat = new TextBox();
            _Cat = txtCat.Text;
            PhtxtCat.Controls.Add(txtCat);
            Session["Dynalbl"] = lblCat;
            Session["Dynatxt"] = txtCat;
        }
        protected void lnkSubCat_Click(object sender, EventArgs e)
        {
            //Panel1.Visible = true;
            //Panel2.Visible = true;
            lblCat = (Label)Session["Dynalbl"];
            txtCat = (TextBox)Session["Dynatax"];
            PHsubCat.Controls.Add(lblCat);
            PHsubCat.Controls.Add(txtCat);
            Label lblSubcat = new Label();
            lblSubcat.Text = "Enter new Sub-Category: ";
            PHsubCat.Controls.Add(lblSubcat);
            txtSubCat = new TextBox();
            _SubCat = txtSubCat.Text;
            PhtxtSubCat.Controls.Add(txtSubCat);
        }
