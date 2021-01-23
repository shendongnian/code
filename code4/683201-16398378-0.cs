        protected void btn_selectgridview_Click(object sender, EventArgs e)
        {
            int k = 0;
            int checkBoxColumnIndex = 2; //Here you should specify the cell containing the checkBox
            foreach (GridViewRow item in gvrepair_details.Rows)
            {
                RadioButton rb = (RadioButton)item.Cells[checkBoxColumnIndex].FindControl("CheckBox1");
                if (rb != null && rb.Checked) //Check if rb is null
                {
                    k++;
                    string bookname = item.Cells[1].Text;
                    string categoryname = item.Cells[2].Text;
                    string subcategory = item.Cells[3].Text;
                    string shelf_no = item.Cells[4].Text;
                    string isbn = item.Cells[5].Text;
                    string edition = item.Cells[6].Text;
                    string status = item.Cells[7].Text;
                    InsertData(bookname, categoryname, subcategory, shelf_no, isbn, edition, status);
                }
            }
            //Checkther whether atleast one check box is selected or not
            if (k == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script language=JavaScript>alert('select the value in grid');</script>");
                return;
            }
        }
