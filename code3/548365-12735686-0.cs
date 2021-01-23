    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
         string row_id = (((HiddenField)(GridView1.Rows[e.RowIndex].FindControl("po_id_hf"))).Value);
        GridView2.DataSource = View_SP.v_asn_detail_by_asn_number(Int32.Parse(row_id));
        GridView2.DataBind();
        
        step2.Visible = false;
        step3.Visible = true;
    }
