    SqlConnection CN = new SqlConnection(constring); // declare connection as CN
    string Query = "select  (Table_MAL_MEZANYAMASROF.MOKHASASMEZANYA- sum (MAL_ERTEBAT.MONY)) as 'debit' from Table_MAL_MEZANYAMASROF,MAL_ERTEBAT where Table_MAL_MEZANYAMASROF.BANDNO=MAL_ERTEBAT.BANDNO and  MAL_ERTEBAT.BANDNO = @BandNo and MAL_ERTEBAT.BANDNAME = @BandName group by Table_MAL_MEZANYAMASROF.MOKHASASMEZANYA" // declare query as string Query
    CN.Open(); // open connection
    using (var cmd = new SqlCeCommand(Query, CN)) // initialize a new SQL command
    {
        cmd.Parameters.Add("@BandNo", SqlDbType.NVarChar, 100);
        cmd.Parameters.Add("@BandName", SqlDbType.NVarChar, 100);
        cmd.Parameters["BandNo"].Value = EdkhalBayanto.txtBandNo.Text;
        cmd.Parameters["BandName"].Value = EdkhalBayanto.txtBandName.Text;
        result = (string) cmd.ExecuteScalar(); // returns the first row of the first column, ignores everything else
    }
    CN.Close(); // close connection
    MessageBox.Show(result); // show the result in a messagebox
