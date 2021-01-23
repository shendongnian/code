    ArrayList demo = new ArrayList();
    demo.Add(tbxProjName.Text);
    string DatabaseFieldValues;
    foreach (string dataType in demo)
    {
        DatabaseFieldValues += dataType + ",";
        Response.Write(DatabaseFieldValues);
    } 
    Session["DatabaseFieldValuesSession"] = DatabaseFieldValues; 
    Response.Write(Session["DatabaseFieldValuesSession"]);
