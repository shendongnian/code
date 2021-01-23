    namespace System.Windows.Forms
    {
        public static class ComboBoxExtensions
        {
            public static void Load(this ComboBox comboBox, string sql, string valueMember, string displayMember)
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    cnn.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapater(sql, cnn))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        comboBox.ValueMember = valueMember;
                        comboBox.DisplayMember = displayMember;
                        comboBox.DataSource = dt;
                    }
                }
            }
        }
    }
