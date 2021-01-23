               var oficio= new SqlParameter
                {
                    ParameterName = "pOficio",
                    Value = "0001"
                };
    
                
                using (var dc = new PCMContext())
                {
                    return dc.Database.SqlQuery<ProyectoReporte>("exec SP_GET_REPORTE @pOficio",
                        oficio).ToList<ProyectoReporte>();
     
                }
