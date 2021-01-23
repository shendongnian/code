            dgvSubscriptions.AutoGenerateColumns = false;
            dgvSubscriptions.ColumnCount = 1;
            dgvSubscriptions.Columns[0].Name = "ID";
            dgvSubscriptions.Rows.Clear();
            bool firstinit = true;
            for (int i = 0; i < 12; i++)
            {
                dgvSubscriptions.Rows.Add();
                #region Grid Column Names
                DataGridViewComboBoxColumn mntCmb = new DataGridViewComboBoxColumn();
                mntCmb.HeaderText = "Month";
                mntCmb.Name = "Month";
                //mntCmb.DataSource = dt;
                mntCmb.DisplayMember = "paidformonth";
                mntCmb.DataPropertyName = "paidformonth";
                //mntCmb.ValueMember = "paidformonth";
                mntCmb.DefaultCellStyle.NullValue = dt.Rows[i][1].ToString(); ;
                mntCmb.ReadOnly = true;
                if (firstinit)
                {
                    dgvSubscriptions.Columns.Add(mntCmb);
                }
                DataGridViewComboBoxColumn yearCmb = new DataGridViewComboBoxColumn();
                yearCmb.HeaderText = "Year";
                yearCmb.Name = "Year";
                //yearCmb.DataSource = dt;
                yearCmb.DisplayMember = "paidforyear";
                //yearCmb.ValueMember = "paidforyear";
                yearCmb.DataPropertyName = "paidforyear";
                yearCmb.DefaultCellStyle.NullValue = dt.Rows[i][2].ToString(); ;
                yearCmb.ReadOnly = true;
                if (firstinit)
                {
                    dgvSubscriptions.Columns.Add(yearCmb);
                }
                DataGridViewTextBoxColumn amount = new DataGridViewTextBoxColumn();
                amount.HeaderText = "Subscription Amount";
                amount.Name = "Subscription Amount";
                amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //amount.DataPropertyName = dt.Rows[i][2].ToString();
                amount.DataPropertyName = "subamount";
                amount.DefaultCellStyle.NullValue = dt.Rows[i][0].ToString(); ;
                amount.ReadOnly = true;
                if (firstinit)
                {
                    dgvSubscriptions.Columns.Add(amount);
                }
                firstinit = false;
                #endregion
                //time you add column 
            }
