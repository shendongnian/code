    if (dr_art_line_2.Rows.Count > 0)
    {   
        int ID_line = dr_art_line_1.Rows.IndexOf(dr_art_line); 
        
        //int ID_line = (int)ds.Tables["Line"].Select()[0]["Line_Id"];
        int ID = (int)ds.Tables["QuantityInIssueUnit"].Select()[ID_line]["Line_Id"];
        
        QuantityInIssueUnit_value = Convert.ToString(dr_art_line_2.Rows[ID]["QuantityInIssueUnit_Text"]);
        QuantityInIssueUnit_uom = Convert.ToString(dr_art_line_2.Rows[ID]["uom"]);    
    }
    else
    {
        QuantityInIssueUnit_value = "";
        QuantityInIssueUnit_uom = "";
    }
