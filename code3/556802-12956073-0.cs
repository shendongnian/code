    DataSet dsMain = new DataSet();
    DataRelation newRelation = new DataRelation("processData",
        new DataColumn[] { dtNames.Columns["EmpName"], dtNames.Columns["EmpRole"] },
        new DataColumn[] {dtDetails.Columns["EmpName"], dtDetails.Columns["EmpRole"]}
    );
    dsMain.Relations.Add(newRelation);
