    protected void ButtonNext_Click(object sender, EventArgs e)
    {
    	if (Session["ds"] != null)
    	{
    		int inc;
    		if(Session["inc"]==null)
    		{
    		  Session["inc"] =0;
    		}
    		if(int.TryParse(Session["inc"], out inc)
    		{
    			inc++;
    			Session["inc"] = inc;
    			DataSet dataSetH = (DataSet)Session["ds"];
    
    			if (inc <= dataSetH.Tables[0].Rows.Count)
    			{
    				DataRow dRow = dataSetH.Tables[0].Rows[inc];
    				TextBoxCopyID.Text = dRow.ItemArray.GetValue(0).ToString();
    				TextBoxSoftwareName.Text = dRow.ItemArray.GetValue(1).ToString();
    				DropDownListAssetName.SelectedItem.Text = dRow.ItemArray.GetValue(2).ToString();
    				DropDownListLocation.SelectedItem.Text = dRow.ItemArray.GetValue(3).ToString();
    				TextBoxLicence.Text = dRow.ItemArray.GetValue(4).ToString();
    				DropDownListType.SelectedItem.Text = dRow.ItemArray.GetValue(5).ToString();
    				DropDownListState.SelectedItem.Text = dRow.ItemArray.GetValue(6).ToString();
    				TextBoxInstall.Text = dRow.ItemArray.GetValue(7).ToString();
    			}
    		}
    	}
    }
