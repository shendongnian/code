    DataColumn imgCount = new DataColumn("imgCount",Type.GetType("System.Int32"));
    DataColumn imgCount2 = new DataColumn("imgCount",Type.GetType("System.Int32"));
    dtS = dvSho.ToTable("shooters");
    dtS.Columns.Add(imgCount);
    dtF = dvFys.ToTable("fyshwick");
    dtF.Columns.Add(imgCount2);
