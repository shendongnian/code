            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Values");
            dt.Rows.Add(new object[] {"Sagar","Sagar_Value" });
            dt.Rows.Add(new object[] { "Hari", "Hari_Value" });
            dt.Rows.Add(new object[] { "Ram", "Ram_Value" });
            LoadDynamicCombo(comboBox1, dt);
            dt.Clear();
            dt.Rows.Add(new object[] { "one", "one" });
            LoadDynamicCombo(comboBox2, dt);
        }
        public void LoadDynamicCombo(ComboBox _cmb,DataTable dt )
        {
            _cmb.DataSource = dt.Copy();
            _cmb.DisplayMember = "Name";
            _cmb.ValueMember = "Values";
            
        }
