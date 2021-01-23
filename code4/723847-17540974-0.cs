                SqlParameter param = new SqlParameter();
                param.ParameterName = "@upload";
                param.Value = upload;
                param.DbType = System.Data.DbType.Boolean
                cmd.Parameters.Add(param);
