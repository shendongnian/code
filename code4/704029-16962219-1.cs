    public void DeletePersonById(int id)
    {
        var cmd = new SqlCommand();
        cmd.Connection = ...
        cmd.CommandText = "delete from persons where person_id = @id");
        cmd.AddParameters(new { id });
        cmd.ExecuteNonQuery();
        ...
