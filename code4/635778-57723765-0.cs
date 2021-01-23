        private const string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Matt\Documents\coffeeShop.mdf;Integrated Security=True;Connect Timeout=30";
        protected void SubmitBTN_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Table (coffeeName, coffeeGrid, coffeeOrigin, coffeePrice, coffeeQty, coffeeRRP) VALUES (@name, @grid, @origin, @price, @qty, @rrp)";
            using(SqlConnection conn = new SqlConnection(connection))
            using(SqlCommand command = new SqlCommand(query, connection))
            {        
                String coffeeName = NameTXT.Text;
                String coffeeGrid = GrindTXT.Text;
                String coffeeOrigin = OriginTXT.Text;
                String coffeePrice = PriceTXT.Text;
                String coffeeQty = QuantityTXT.Text;
                String coffeeRRP = RRPTXT.Text;
                command.Parameters.AddWithValue("@name", coffeeName);
                command.Parameters.AddWithValue("@grid", coffeeGrid);
                command.Parameters.AddWithValue("@origin", coffeeOrigin);
                command.Parameters.AddWithValue("@price", coffeePrice);
                command.Parameters.AddWithValue("@qty", coffeeQty);
                command.Parameters.AddWithValue("@rrp", coffeeRRP);
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException Ex)
                {
                    
                    console.WriteLine( "Error message: " + Ex);
                }
                finally
                {
                    command.Connection.Close();
                }        
            }
                        
        }
