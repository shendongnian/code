    protected void btnSave_Click(object sender, EventArgs e)
    {
                        if (ddpcustomer.SelectedIndex == 0 && ddpproperty.SelectedIndex == 0)
                        {
                            DataSet ds1 = Tbl_MasterBooking.getDetailsforBookingSummaryWithoutStatusCheckinDate(inputField.Text, inputField1.Text, userId, Cid);
                            GVBookingSummary.DataSource = ds1;
                            GVBookingSummary.DataBind();
                            GridView1.DataSource = ds1;
                            GridView1.DataBind();
                        }
                        else if (ddpcustomer.SelectedIndex != 0 && ddpproperty.SelectedIndex == 0)
                        {
                            DataSet ds1 = Tbl_MasterBooking.getDetailsforBookingSummaryWithoutStatusWithCustNameCheckinDate(inputField.Text, inputField1.Text, userId, Cid,ddpcustomer.SelectedItem.Text);
                            GVBookingSummary.DataSource = ds1;
                            GVBookingSummary.DataBind();
                            GridView1.DataSource = ds1;
                            GridView1.DataBind();
                        }
                        else if (ddpcustomer.SelectedIndex != 0 )
                        {
                            DataSet ds1 = Tbl_MasterBooking.getDetailsforBookingSummaryWithoutStatusWithPnameCheckinDate(inputField.Text, inputField1.Text, userId, Cid, ddpproperty.SelectedItem.Text);
                            GVBookingSummary.DataSource = ds1;
                            GVBookingSummary.DataBind();
                            GridView1.DataSource = ds1;
                            GridView1.DataBind();
                        }
                        else if (ddpcustomer.SelectedIndex != 0 && ddpproperty.SelectedIndex != 0)
                        {
                            DataSet ds1 = Tbl_MasterBooking.getDetailsforBookingSummaryWithoutStatusWithPnameandCustNameCheckinDate(inputField.Text, inputField1.Text, userId, Cid, ddpproperty.SelectedItem.Text, ddpcustomer.SelectedItem.Text);
                            GVBookingSummary.DataSource = ds1;
                            GVBookingSummary.DataBind();
                            GridView1.DataSource = ds1;
                            GridView1.DataBind();
                        }
     }
