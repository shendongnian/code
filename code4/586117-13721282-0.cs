    using System.Linq;
    ...
    //Initialization, please ignore it, as you have data tables A and B populated from the database
    /********************/
    DataTable A, B;
    A = new DataTable();
    B = new DataTable();
    A.Columns.Add("Id",typeof(int));
    A.Columns.Add("ForeignId",typeof(int));
    B.Columns.Add("Id",typeof(int));
    B.Columns.Add("Name", typeof(string));
    A.Rows.Add(1,1);
    B.Rows.Add(1,"First");
    /********************/
    var aEnum = A.AsEnumerable();
    var bEnum = B.AsEnumerable();
    dataGridView1.DataSource = (from a in aEnum
                                join b in bEnum on a["ForeignId"] equals b["Id"]
                                select new
                                {
                                    Id=a["Id"],
                                    ForeignId = a["ForeignId"],
                                    ForeignName = b["Name"]
                                }).ToList();
