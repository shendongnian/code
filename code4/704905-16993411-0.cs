    private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e) {
          listBox1.ClearSelected();
          if (dataGridView1.SelectedRows.Count == 1){
            List<CatProd> catProdLijst = catprod.Where(c => c.ProdID == 
              (int)dataGridView1.SelectedRows[0].Cells["ID"].Value).ToList();
            foreach (CatProd cp in catProdLijst) {
              for (int i = 0; i < listBox1.Items.Count; i++) {
                var category = listBox1.Items[i] as Categorie;
                if (category.ID == cp.CatID) {
                  listBox1.SetSelected(i, true);
                }
              }
            }
          }
        }
