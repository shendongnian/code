    DataTable DT; // Obtained from the relevent DGV.
    DataView view = new DataView(DT);
    DataView thisDV = new DataView();
    // Then you can use...
    thisDV.Find(thisOrThat);
    thisDV.FindRows(thisOrThat);
