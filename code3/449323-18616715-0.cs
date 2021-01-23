        private void TxtNama_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrEmpty(TxtNama.Text);
            this.errorProvider1.SetError(TxtNama, "Nama Barang Harus Diisi..!!");            
        }
        private void CmdSave_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("Simpan Data Barang..?" , "SIMPAN DATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
        }
