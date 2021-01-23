        public int GetLookupCodeFromShortCode(short tableType, string shortCode)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("dbo.fnGetLookupCodeFromShortCode", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30;
                    SqlCommandBuilder.DeriveParameters(cmd);
                    cmd.Parameters["@sintTableType"].Value = tableType;
                    cmd.Parameters["@vchrShortCode"].Value = shortCode;
                    cmd.Parameters["@chrLanguage"].Value = "en";
                    cmd.Parameters["@chrCountry"].Value = "en";
                    cmd.ExecuteNonQuery();
                    return (int)cmd.Parameters["@RETURN_VALUE"].Value;
                }
            }
        }
