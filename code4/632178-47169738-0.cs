    PnIdProject oPnIdProject =
        (PnIdProject)PlantApplication.CurrentProject.ProjectParts["PnID"];
    //Assuming you want Project Number from the "General" category.  If you have
    //a custom category property you want, just replace "General" with the name
    //of the custom category
    List<ProjectProperty> metaData = 
        oPnIdProject.GetProjectPropertyMetadata("General");
    string projectNumberString = "";
    foreach (ProjectProperty prop in metaData)
    {
        if (prop.Name == "Project_Number")
        {
            projectNumberString = oPnIdProject.GetProjectPropertyValue(prop);
        }
    }
