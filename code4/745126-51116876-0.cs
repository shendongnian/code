    DataTable dt=new DataTable();
    //Assigning some data into dt. with columns ID, Name, Age. 
    DataRow[] dr=dt.Select("ID=100");
    string PersonID=dr[0].ItemArray[0].Tostring().trim(); //first column is ID
    string PersonName=dr[0].ItemArray[1].Tostring().trim(); //second column is Name
    string PersonAge=dr[0].ItemArray[2].Tostring().trim(); //third column is Age
