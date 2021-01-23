    SqlConnection Con = new SqlConnection(conString);
    SqlCommand Com = new SqlCommand();
    string SQLQuery = "SELECT * FROM table WHERE ";
    int i=1;
    foreach(word in words)
    {
          Com.Parameters.Add("@word"+i.ToString(),SqlDbType.Text).Value = word;
          SQLQuery = SQLQuery + " column1 = '@word"+i.ToString()+"' AND ";
          i++;
    }
    Com.CommandText =SQLQuery;
