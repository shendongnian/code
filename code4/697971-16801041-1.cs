    private void button1_Click(object sender, EventArgs e)
    {
        using (var con = new SqlConnection("Database= hotel; server= roger\SQLEXPRESS"))
        using (var cmd = new SqlCommand("insert into CheckIn VALUES (@TransactionId,@GuestName,@RoomType,@RoomNo,@ReservationDate,@CheckInDate,@CheckOutDate,@NoOfDays,@NoOfAdults,@NoOfChildren)", con))
        {
            cmd.Parameters.Add("@TransactionId", SqlDbType.Int).Value = int.Parse(textBox1.Text);
            cmd.Parameters.Add("@GuestName", SqlDbType.NVarChar, 50).Value = textBox2.Text;
            cmd.Parameters.Add("@RoomType", SqlDbType.NVarChar, 10).Value = textBox3.Text;
            cmd.Parameters.Add("@RoomNo", SqlDbType.NChar, 4).Value = textBox4.Text;
            cmd.Parameters.Add("@ReservationDate", SqlDbType.DateTime).Value = datetime.Parse(textBox5.Text);
            cmd.Parameters.Add("@CheckInDate", SqlDbType.DateTime).Value = datetime.Parse(textBox6.Text);
            cmd.Parameters.Add("@CheckOutDate", SqlDbType.DateTime).Value = datetime.Parse(textBox7.Text);
            cmd.Parameters.Add("@NoOfDays", SqlDbType.Int).Value = int.Parse(textBox8.Text);
            cmd.Parameters.Add("@NoOfAdults", SqlDbType.Int).Value = int.Parse(textBox9.Text);
            cmd.Parameters.Add("@NoOfChildren", SqlDbType.Int).Value = int.Parse(textBox10.Text);
    
            con.Open();
            cmd.ExecuteNonQuery();
        }
        MessageBox.Show("DATA ADDED SUCCESSFULLY!!");
    }
