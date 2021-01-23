    using (SqlConnection cn = new SqlConnection("Data Source=localhost;Database=AdventureWorks;Integrated Security=SSPI"))
    {
        cn.Open();
        cn.Close();
    }
