            if (lstView_KQ.SelectedItems.Count > 0)
            {
                ListViewItem itiem = stView_KQ.SelectedItems[lstView_KQ.SelectedItems.Count - 1];
                if (itiem != null)
                    foreach (ListViewItem lv in lstView_KQ.SelectedItems)
                    {
                        txtMaNV.Text = lv.SubItems[0].Text;
                        cmbCV.Text = lv.SubItems[1].Text;
                        txtHoNV.Text = lv.SubItems[2].Text;
                        txtTenNV.Text = lv.SubItems[3].Text;
                        txtNgaysinh.Text = lv.SubItems[4].Text;
                        txtGioiTinh.Text = lv.SubItems[5].Text;
                        txtDiaChi.Text = lv.SubItems[6].Text;
                        txtSDT.Text = lv.SubItems[7].Text;
                        txtCMND.Text = lv.SubItems[8].Text;
                    }
            }
        }      
