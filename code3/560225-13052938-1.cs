            ASPxGridView grd = new ASPxGridView(); //create instance of aspxgridview
            grd.AutoGenerateColumns = true; //this should be set true so that automatically data gets bind
            grd.ID = "Test"; //give any id
            grd.DataSource = objs; //Datasource Id - could be objectdatasource
            grd.KeyFieldName = "TestField";  //keyfield name in the datasource
            this.Controls.Add(grd);             
            grd.DataBind();
    	    ASPxGridViewExporter1.GridViewID = "Test";
            ASPxGridViewExporter1.WritePdfToResponse();
            this.Controls.Remove(grd); //would remove the temporarily created instance of devex grid
    	
