    CultureInfo provider = CultureInfo.InvariantCulture;
    System.Globalization.DateTimeStyles style = DateTimeStyles.None;
    DateTime dt;
    DateTime.TryParseExact(txt_dob.Text, "m-d-yyyy", provider, style, out dt);
    mycom = new SqlCommand("insert into mytable(dtCol1) values(@datevalue)", mycon);
    cmd.Parameters.Add("@datevalue",SqlDbType.DateTime).Value =dt;
    mycom.ExecuteNonQuery();
