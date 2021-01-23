    if (roomGender.Equals("M"))
    {
    	if (gender.Equals("F"))
    	{
    		row.Cells[5].BackColor = Color.FromName("#FF0000");
    		args.IsValid = false;
    		vldGender.ErrorMessage = building + " " + room + ": You cannot place a female in this space";
    	}
    	else
    	{
    		vldGender.ErrorMessage = "";
    		vldGender2.ErrorMessage = "";
    	}
    	
    }
    //end male gender check
    //Female gender check
    else if (roomGender.Equals("F"))
    {
    	if (gender.Equals("M"))
    	{
    		row.Cells[5].BackColor = Color.FromName("#FF0000");
    		args.IsValid = false;
    		vldGender.ErrorMessage = building + " " + room + ": You cannot place a male in this space";
    	}
    	else
    	{
    		vldGender.ErrorMessage = "";
    		vldGender2.ErrorMessage = "";
    	}
    }
    //end female gender check
    // No gender selected
    else
    {
    	row.Cells[5].BackColor = Color.FromName("#FF0000");
    	args.IsValid = false;
    	vldGender2.ErrorMessage = building + " " + room + ": A gender must be selected";
    }
    
    //Validate Names
    string last = ((TextBox)row.FindControl("txtLast")).Text;
    string first = ((TextBox)row.FindControl("txtFirst")).Text;
    
    if (string.IsNullOrEmpty(last))
    {
    	row.Cells[3].BackColor = Color.FromName("#FF0000");
    	args.IsValid = false;
    	vldLast.ErrorMessage = building + " " + room + ": The last name cannot be blank";
    }
    else            
    	vldLast.ErrorMessage = "";
    
    if (string.IsNullOrEmpty(first))
    {
    	row.Cells[4].BackColor = Color.FromName("#FF0000");
    	args.IsValid = false;
    	vldFirst.ErrorMessage = building + " " + room + ": The first name cannot be blank";
    }
    else
    	vldFirst.ErrorMessage = "";
    			
    if (!(regLast.IsValid))
    {
    	row.Cells[3].BackColor = Color.FromName("#FF0000");
    	regLast.ErrorMessage = building + " " + room + ": The last name is incorrect, please check the name";
    }
    
    if (!(regFirst.IsValid))
    {
    	row.Cells[4].BackColor = Color.FromName("#FF0000");
    	regFirst.ErrorMessage = building + " " + room + ": The first name is incorrect, please check the name";
    }
