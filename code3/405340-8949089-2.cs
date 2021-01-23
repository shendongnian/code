    string [] numbers = {"12", "23", "34"};
    string [] parameters = new string[numbers.Length];
    for (int i = 0; i < numbers.Length; i++)
    {
         cmd.Parameters.AddWithValue("param"+i, numbers[i]);
         parameters[i] = "@param" + i;
    }
    
    var str = String.Join(",", parameters);
    string sql = String.Format("SELECT * FROM Items WHERE ItemIds IN({0})",str);
