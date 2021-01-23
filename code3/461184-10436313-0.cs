    public void updatedb() {
         MySqlCommandBuilder cmb = new MySqlCommandBuilder(da);
         da.Update(ds);
         da.AcceptChanges();
    }
