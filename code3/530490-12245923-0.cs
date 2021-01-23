    DataTable dt = new DataTable();
    // I assumed that dt has some data
 
    Session["dataTable"] = dt; // Saving datatable to Session
    // Retrieving 
    DataTable dtt = (DataTable) Session["dataTable"]; // Cast it to DataTable
    int a = 43432;
    Session["a"] = a;
    // Retrieving 
    int aa = (int) Session["a"];
