    int rowIndex = 0;
    StringCollection sc = new StringCollection(); 
    for (int i = 1; i <= dtCurrentTable.Count; i++)
    {
    //extract the TextBox values
    Label box1 = (Label)GridView2.Rows[rowIndex].Cells[0].FindControl("lblbedroom");
    DropDownList box2 = (DropDownList)GridView2.Rows[rowIndex].Cells[0].FindControl("ddpAccomodates");
    DropDownList box3 = (DropDownList)GridView2.Rows[rowIndex].Cells[0].FindControl("ddpBathroom");
    DropDownList box4 = (DropDownList)GridView2.Rows[rowIndex].Cells[0].FindControl("ddpBedType");
    TextBox box5 = (TextBox)GridView2.Rows[rowIndex].Cells[0].FindControl("txtPrices");
    DropDownList box6 = (DropDownList)GridView2.Rows[rowIndex].Cells[0].FindControl("ddpMiniStay");
    //get the values from the TextBoxes
    //then add it to the collections with a comma "," as the delimited values
    sc.Add("Private Room" + box1.Text + "," + box2.SelectedItem.Value + "," + box3.SelectedItem.Value + "," + box4.SelectedItem.Value + "," + box5.Text + "," + box6.SelectedItem.Value);
    rowIndex++;
    }
    InsertToDb(sc);
