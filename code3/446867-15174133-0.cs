            this.Validate();
            
            try
            {
                dgvArticles.CurrentRow.Cells[1].Value = txtSubject.Text;
                dgvArticles.CurrentRow.Cells[2].Value = rtbBodyContent.Text;
                dgvArticles.CurrentRow.Cells[3].Value = pbPrimaryPicture.Image;
                dgvArticles.CurrentRow.Cells[4].Value = pbSecondaryPicture.Image;
                dgvArticles.CurrentRow.Cells[5].Value = pbThirdPicture.Image;
            }
            catch
            {
                MessageBox.Show(e.ToString());
            }
            AccessingNetFamerDatabase anfdArticles = new AccessingNetFamerDatabase();
            if (_dsArticles!= null)
            {
                SqlCommandBuilder _sqlCBArticles = new SqlCommandBuilder(AccessingNetFamerDatabase._sqlDataAdapter);
                AccessingNetFamerDatabase._sqlDataAdapter.Update(_dsArticles.Tables[0]);
            }
        }
