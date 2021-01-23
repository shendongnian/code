     string text;
     foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
     {
         //MessageBox.Show(cell.Value.ToString());
         text +=cell.Value.ToString();
     }
     MessageBox.Show(text);
