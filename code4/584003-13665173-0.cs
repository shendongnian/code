    public static string GetFormatoMoneda(object objCantidad)
    {
        var decCantidad = Convert.ToDecimal(decCantidad);
        //Get data from currency (Dollars, Pesos, Euros, etc.)
        DataRow dr = ConexionBD.GetInstanciaConexionBD().GetTipoDeMonedaPrincipal((int)HttpContext.Current.Session["Grupo"]);
        return dr["Signo"] + Math.Round(decCantidad, 2).ToString("C").Substring(1) + " " + dr["Abreviatura"];
    }
