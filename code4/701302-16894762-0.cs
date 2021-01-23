    int counter=0;
    While(blah blah)
    {
      if (bVisitorPhoto != null)
      {
        string Picture = photo+counter.ToString();
        SqlParameter picparameter = new SqlParameter();
        picparameter.SqlDbType = SqlDbType.Image;
        picparameter.ParameterName = Picture;
        picparameter.Value = bVisitorPhoto;
        command.Parameters.Add(picparameter);
        VisitorPhoto = "@"+Picture;
      }
      string query = "insert into table Values (Picture, "PersonName");       
      counter++;
    }
