    public void TotalCupom(int cupom)
    { 
        float SAIDA;           
        SqlDataAdapter da2 = new SqlDataAdapter();
        if (conex1.State == ConnectionState.Closed)
        {
            conex1.Open();
        }
        SqlCommand Totalf = new SqlCommand("SELECT dbo.Tcupom(@code)", conex1);
        SqlParameter code1 = new SqlParameter("@code", SqlDbType.Int);
        code1.Value = cupom;
        SAIDA = Totalf.ExecuteScalar();
    
        return SAIDA;
    }
