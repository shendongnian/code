            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frmStock frm2 = new frmStock();
                frm2.Show();
                frm2.txtStockID.Text = dr.Cells[0].Value.ToString();
                frm2.txtConfigID.Text = dr.Cells[1].Value.ToString();
                frm2.txtProductname.Text = dr.Cells[2].Value.ToString();
                frm2.txtFeatures.Text = dr.Cells[3].Value.ToString();
                frm2.txtPrice.Text = dr.Cells[4].Value.ToString();
                frm2.txtQty.Text = dr.Cells[5].Value.ToString();
                frm2.txtTotalPrice.Text = dr.Cells[6].Value.ToString();
                frm2.dtpStockDate.Text = dr.Cells[7].Value.ToString();
                frm2.btnUpdate.Enabled = true;
                frm2.btnDelete.Enabled = true;
                frm2.btnSave.Enabled = false;
                frm2.label8.Text = label1.Text;
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
