    public static List<NumericFormulaDO> SelectAllNumericFormulas()
    {
        var nFormulas = new Dictionary<int, NumericFormulaDO>();
        string queryString = @"
        SELECT *
        FROM    NumericFormula nf 
                Left Join Unit u on u.Unit_Id = nf.Unit_Id 
                Left Join UnitType ut on ut.UnitType_Id = u.UnitType_Id 
                Join RPN r on r.RPN_Id = nf.RPN_Id 
                Join RPNDetails rd on rd.RPN_Id = r.RPN_Id 
                Join Parameter par on par.Parameter_Id = rd.Parameter_Id where nf.NumericFormula_Id<=10000";
        using (var connection = new SqlConnection(connectionString))
        {  
            connection.Open();
            using (var command = new SqlCommand(queryString, connection));
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var det = new RPNDetailsDO();
                    det.RPNDetails_Id = (int) reader.GetValue("RPNDetails_Id");
                    det.RPN_Id = (int) reader.GetValue("RPN_Id");
                    det.Identifier = (string) reader.GetValue("Identifier");
                    det.Parameter.Architecture = (string)reader.GetValue("Architecture");
                    det.Parameter.Code = (string)reader.GetValue("Code");
                    det.Parameter.Description = (string)reader.GetValue("Description");
                    det.Parameter.Parameter_Id = (int) reader.GetValue("Parameter_Id");
                    det.Parameter.ParameterType = (string)reader.GetValue("ParameterType");
                    det.Parameter.QualityDeviationLevel = (string)reader.GetValue("QualityDeviationLevel");
                    NumericFormulaDO parent = null;
                    if (!nFormulas.TryGetValue((int)reader.GetValue("RPN_Id"), out parent)
                    {
                        parent = CreatingNumericFormulaDO(reader, det);
                        nFormulas.Add(parent.RPN.RPNID, parent);
                    }
                    else
                    {
                        parent.RPN.RPNDetails.Add(det);
                    }
                }
            }
        }
        return nFormulas.Values.ToList();
    }
