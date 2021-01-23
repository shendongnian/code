        using Oracle.DataAccess;
        using Oracle.DataAccess.Client;
        
        public DataTable ExecuteSP()
        {
            using (OracleConnection cn = new OracleConnection(GetConnectionString()))
            {
                OracleDataAdapter da = new OracleDataAdapter();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "PR_ABC_P_ALTA_TARJETA_PAYWARE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.Parameters.Add("Lc_Param_Issuer", OracleDbType.Varchar2, issuer, ParameterDirection.Input);
                cmd.Parameters.Add("Ln_Param_Valid_Product", OracleDbType.Varchar2, DropDownListProducto.SelectedValue.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("Ln_Param_Total", OracleDbType.Int32, Convert.ToInt32(TextBoxCantidad.Text) , ParameterDirection.Input);
                cmd.Parameters.Add("Lc_Param_User", OracleDbType.Varchar2, user, ParameterDirection.Input);
                cmd.Parameters.Add("Lc_Encrypted_Password", OracleDbType.Varchar2, pass, ParameterDirection.Input);
                cmd.Parameters.Add("Lc_Exito", OracleDbType.Int32, exito, ParameterDirection.Output);
    
                cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
