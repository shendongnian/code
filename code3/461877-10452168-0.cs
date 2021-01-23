        SqlConnection connect = new SqlConnection
                         ("Server=.;database=PictureDb;integrated security=true");
        SqlCommand command = new SqlCommand
                            ("select fldPic from tblUsers where fldCode=1", connect);
        //for retrieving the image field in SQL SERVER EXPRESS
        //Database you should first bring
        //that image in DataList or DataTable
        //then add the content to the byte[] array.
        //That's ALL!
        SqlDataAdapter dp = new SqlDataAdapter(command);
        DataSet ds = new DataSet("MyImages");
        byte[] MyData = new byte[0];
        dp.Fill(ds, "MyImages");
        DataRow myRow;
        myRow = ds.Tables["MyImages"].Rows[0];
        MyData = (byte[])myRow["fldPic"];
        MemoryStream stream = new MemoryStream(MyData);
        //With the code below, you are in fact converting the byte array of image
        //to the real image.
        pictureBox2.Image = Image.FromStream(stream);
