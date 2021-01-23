    using (var cm = new OracleCommand("select round(avg(rating),1)As AvgRating from rates where id_rec = @id", con))
    {
        cm.Parameters.AddWithValue("@id", id);
        object avgRating = cm.ExecuteScalar();
        if (!(avgRating is DBNull))
        {
            textBox5.Text = avgRating.ToString();
        }
    }
