    SqlCeCommand cmd = new SqlCeCommand();
    SqlCeConnection conn = new SqlCeConnection("connString");
    cmd.Connection = conn;
    cmd.CommandText = "SELECT COUNT(*) FROM yourTable";
    var count = cmd.ExecuteScalar();
    for (int i = 0; i <= int.Parse(count.ToString()); i++)
    {
         if (dataGridViewCategories.Rows[i].Cells["cellName"].Value.ToString() == "0")
         {
            dataGridViewCategories.Rows[i].Cells["coulmnName"].Value = "Inkomst";
         }
         else
         {
            dataGridViewCategories.Rows[i].Cells["coulmnName"].Value = "Uitgave";
         }
    }
