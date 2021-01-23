     private void PickValues(int SerialNum) 
    { 
        DataSet ds = new DataSet(); 
        try 
        { 
            string Query = "SELECT * FROM tw_main WHERE sno = " + SerialNum; 
            ds = reuse.ReturnDataSet(Query, "Scheme"); 
 
            //Add Scheme Code to new Session Variable 
            Session.Add("SerialNumber", ds.Tables[0].Rows[0]["sno"].ToString()); 
            //Set Update Flag 
            TaskFlag = "UPDATE"; 
 
            //Fill values of selected record on the Entry Form 
            if (ds.Tables[0].Rows[0]["schm_code"].ToString().Length > 0) 
                lblSchemeCode.Text = ds.Tables[0].Rows[0]["schm_code"].ToString(); 
 
            ddlType.SelectedValue = ds.Tables[0].Rows[0]["schemetype"].ToString(); ddlDistrict.Text = ds.Tables[0].Rows[0]["dist_nm"].ToString(); ddlBlock.Text = ds.Tables[0].Rows[0]["block_nm"].ToString(); 
            txtSchemeName.Text = ds.Tables[0].Rows[0]["schm_nm"].ToString(); 
            txtPopulation2001.Text = ds.Tables[0].Rows[0]["population_2001"].ToString(); 
            txtSupplySource.Text = ds.Tables[0].Rows[0]["supply_source"].ToString(); 
            txtApprovalYear.Text = ds.Tables[0].Rows[0]["yr_approval"].ToString(); 
            txtApprovalLetterNum.Text = ds.Tables[0].Rows[0]["approval_letter_num"].ToString(); 
            txtApprovalAmount.Text = ds.Tables[0].Rows[0]["sch_apr_amt"].ToString(); 
            txtWaitedLetterNum.Text = ds.Tables[0].Rows[0]["sch_waited_details"].ToString(); 
            txtSchTransferLetterNum.Text = ds.Tables[0].Rows[0]["schm_trans_details"].ToString(); 
            txtSchTransferDate.Text = ds.Tables[0].Rows[0]["schm_trans_date"].ToString(); 
            txtOtherRemarks.Text = ds.Tables[0].Rows[0]["remarks"].ToString(); 
        } 
        catch (Exception ex) 
        { 
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Warning", "alert('" + ex.Message.ToString() + "');",true); 
        } 
        finally 
        { 
            ds.Dispose(); 
            gridSerialNo = 0; 
        } 
    }
