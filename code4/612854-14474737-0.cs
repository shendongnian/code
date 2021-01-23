     SqlCommand upCmd = new SqlCommand(
    "update emp set Name=@Name, Age=@Age where No=@No",con);
     upCmd.Parameters.Add("@Name", SqlDbType.NChar, 10, "Name");
     upCmd.Parameters.Add("@Age", SqlDbType.Int, 4, "Age");
     upCmd.Parameters.Add("@No", SqlDbType.Int, 4, "No");
     sqlDa.UpdateCommand = upCmd;
     sqlDa.Update(dSet,"emp");
