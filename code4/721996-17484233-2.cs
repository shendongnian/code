    query = "INSERT INTO mahasiswa VALUES (@p1,@p2,@p3);";
    using(MySqlConnection koneksi = new MySqlConnection(connectionString))
    using(MySqlCommand perintah = new MySqlCommand(query, koneksi))
    {
         koneksi.Open();
         perintah.Parameters.AddWithValue("@p1", txtnama.Text);
         perintah.Parameters.AddWithValue("@p2", txtjurusan.Text);
         perintah.Parameters.AddWithValue("@p3", txtemail.Text);
         int res = perintah.ExecuteNonQuery();
         if (res == 1)
             MessageBox.Show("Input Data Sukses...");
         else
             MessageBox.Show("Input Data Gagal... ");
    }
