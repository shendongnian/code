    protected void Page_Load(object sender, EventArgs e)
        {
            dsCIInfoTableAdapters.BMC_CORE_BMC_ComputerSystemTableAdapter serverTableAdapter1;
            serverTableAdapter1 = new dsCIInfoTableAdapters.BMC_CORE_BMC_ComputerSystemTableAdapter();
            dsCIInfo.BMC_CORE_BMC_ComputerSystemDataTable newServerTable;
            newServerTable = serverTableAdapter1.GetData();
            var query = (from row in newServerTable.AsEnumerable()
                         where row.Field<string>("Item") == "Server"
                         select row.Field<string>("Name")).Distinct();
            var queryArray = query.ToArray();
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (string row in queryArray)
            {
                sb.Append("\"").Append(row).Append("\",");
            }
            sb.Append("]");
            sb.Replace(",]", "]");
            txtHiddenAutoComplete.Value = sb.ToString();
            
        }
