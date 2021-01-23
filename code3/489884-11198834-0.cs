        private decimal GetMyPrice(DataTable table, string client, string product, DateTime date)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row["productid"] != product) continue;
                if (row["client"] != client) continue;
                if (Convert.ToDateTime(row["startdate"]) < date) continue;
                if (Convert.ToDateTime(row["finaldate"]) > date) continue;
                return Convert.ToDecimal(row["price"]); 
            }
            throw new KeyNotFoundException();               
        }
