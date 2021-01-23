        public void cargill()
        {
            campo = "60435351000319";
            llenar = ifd.consulta_cnpj(campo);
            sola();
        }
        public void sola()
        {
            sri.DataSource = llenar.Tables["tipoender"];
            listBox1.DataSource = sri;
            listBox1.ValueMember = "end_tipoendereco";
            listBox1.DisplayMember = "tpl_descricao";
        }
        
              DataSet grava = new DataSet();
                SqlDataAdapter da4 = new SqlDataAdapter();
                SqlCommandBuilder constru8 = new SqlCommandBuilder(da4);
                SqlParameter codi = new SqlParameter("@emp", SqlDbType.Int);
                codi.Value = codem;
                SqlCommand llena10 = new SqlCommand("dmlpjende", conec1);
                llena10.Parameters.Add(codi);
                llena10.CommandType = CommandType.StoredProcedure;
                da4.SelectCommand = llena10;
                da4.Fill(grava, "endere");
                DataRow dr2 = grava.Tables["endere"].Rows[ni];
                dr2.BeginEdit();
                dr2["id_tipoauditoria"] = 2;
                dr2.EndEdit();
                da4.Update(grava.Tables["endere"]);
                cargill();        
