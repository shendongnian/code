    using(OleDbConnection cn=new OleDbConnection(cnStr))
     {
      using(OleDbCommand cmd=new OleDbCommand())
       {
        cmd.CommandText="DELETE FROM Student WHERE ID=@ID";
        cmd.Connection=cn;
        cmd.Parameters.Add("@ID",SqlDbType.Int).Value=txtStudentIDnumber.Text;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
       }
     }
