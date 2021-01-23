	using (SqlConnection connection = new SqlConnection( ... ))
	{
		connection.Open();
		string sql = @"
					SELECT
						CONVERT(char(80), i.InvDate,3) AS InvDate,
						i.InvoiceNo,
						i.EmployerCode,
						i.TaxAmount + i.SubTotal AS Amount,
						'' AS Payment,
						pd.GivenName
					FROM
						dbo.Invoice i
							LEFT JOIN dbo.PatientDetails pd ON (pd.MedicalRecordID = i.MedicalRecordID)
					WHERE
						InvDate >= @fromDate AND InvDate <= @toDate";
		SqlCommand cmd = new SqlCommand(sql, connection);
		cmd.Parameters.AddWithValue("@fromDate", dtpFrom.SelectedDate);
		cmd.Parameters.AddWithValue("@toDate", dtpTo.SelectedDate);
		using (SqlDataReader reader = cmd.ExecuteReader())
		{
			// do stuff with results
		}
	}
