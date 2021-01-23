      void yourMethod()
     {
      var lbltotalcount = tableLayoutPanel1.Controls.Find("lbltotalcount_" + GridId, true);
              ((Label)lbltotalcount[0]).Invoke((MethodInvoker)delegate
            {
                ((Label)lbltotalcount[0]).Text =     (Convert.ToInt32(((Label)lbltotalcount[0]).Text) + NumOfMatch).ToString();
            });    
            var obj = tableLayoutPanel1.Controls.Find("dgv_" + GridId, true);
           
           ((DataGridView)obj[0]).SelectionChanged += new EventHandler(My_SelectionChanged);
            ((DataGridView)obj[0]).Invoke((MethodInvoker)delegate
            {
                string[] row = new string[] { Word, txturl.Text, Url, NumOfMatch.ToString() };
                DataGridViewRow dgvRow = new DataGridViewRow();
                DataGridViewCell dgvCell;
                dgvCell = new DataGridViewTextBoxCell();                
                dgvCell.Value = Word;
                dgvRow.Cells.Add(dgvCell);                
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = txturl.Text;
                dgvRow.Cells.Add(dgvCell);
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = Url;
                dgvRow.Cells.Add(dgvCell);
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = NumOfMatch.ToString();
                dgvRow.Cells.Add(dgvCell);                                              
                ((DataGridView)obj[0]).Rows.Add(dgvRow);
                ((DataGridView)obj[0]).Refresh();
                ((DataGridView)obj[0]).Update();
              var index = ((DataGridView) obj[0]).RowCount;
              ((DataGridView) obj[0]).SelectedRows[index - 1].Selected = true;
            });  
      }
       void My_SelectionChanged(object sender, EventArgs e)
        {
          // bla bla ...
   
        }
