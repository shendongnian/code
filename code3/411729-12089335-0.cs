    var para6 = new OracleParameter("pOrganizationParentId", OracleDbType.Long)
                            {
                                IsNullable = true,
                            };
            if (string.IsNullOrEmpty(organizationParentId)) para6.Value = null;
            else
            {
                para6.Value = long.Parse(organizationParentId);
            }
