    public List<Payment> GetMemberPaymnets(int memberId)
        {
            List<Payment> Payments = new List<Payment>();
            string SELECT = "SELECT ID,AMOUNT,STARTDAY,ENDDAY FROM Payments WHERE Id = @Id order by endday desc";
            using (sqlConnection = new SqlConnection(sqlConnectionString_WORK))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(SELECT, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = entity.Id;
                    var sqlReader = sqlCommand.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        var payment = new Payment
                        {
                            Id = Convert.ToInt32(sqlReader["Id"]),
                            Amount = Convert.ToDecimal(sqlReader["Amount"]),
                            StartDay = Convert.ToDateTime(sqlReader["StartDay"]),
                            EndDay = Convert.ToDateTime(sqlReader["EndDay"])
                        };
                        Payments.Add(payment);
                    }
                }
            }
            return Payments;
        }
