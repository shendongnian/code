                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM uyeler", baglanti);
     
                da.Fill(dbDataSet1, "uyeler");
                //Set AutoGenerateColumns False
                dataGridView1.AutoGenerateColumns = false;
                //Set Columns Count
                dataGridView1.ColumnCount = 5;
                //Add Columns
                dataGridView1.Columns[0].Name = "İsim"; // name
                dataGridView1.Columns[0].HeaderText = "İsim"; // header text
                dataGridView1.Columns[0].DataPropertyName = "ad"; // field name
                dataGridView1.Columns[1].HeaderText = "Soyisim";
                dataGridView1.Columns[1].Name = "Soyisim";
                dataGridView1.Columns[1].DataPropertyName = "soyad";
                dataGridView1.Columns[2].Name = "Telefon";
                dataGridView1.Columns[2].HeaderText = "Telefon";
                dataGridView1.Columns[2].DataPropertyName = "telefon";
                dataGridView1.Columns[3].Name = "Kayıt Tarihi";
                dataGridView1.Columns[3].HeaderText = "Kayıt Tarihi";
                dataGridView1.Columns[3].DataPropertyName = "kayit";
                dataGridView1.Columns[4].Name = "Bitiş Tarihi";
                dataGridView1.Columns[4].HeaderText = "Bitiş Tarihi";
                dataGridView1.Columns[4].DataPropertyName = "bitis";
                dataGridView1.DataSource = dbDataSet1;
                dataGridView1.DataMember = "uyeler";
