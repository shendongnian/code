    // to get data in grid
    CustomList<wordlistDAO> WordList = null;
    WordList = WordListBLL.GetAllWord();
    GridWord.DataSource = WordList ;
    // create word datatable for filtering 
    DataTable dtWord = null;
    dtWord = new DataTable();
    foreach (DataGridViewColumn colu in GridWord.Columns)
                            dtWord .Columns.Add(new DataColumn(colu.HeaderText));
    foreach (DataGridViewRow row in GridWord.Rows)
    {
       DataRow dr = dtWord.NewRow();
       foreach (DataGridViewCell cell in row.Cells)
            dr[row.Cells.IndexOf(cell)] = cell.Value;
            dtWord .Rows.Add(dr);
    }
    //create data view
    DataView wordlistview = new DataView();
    wordlistview  = new DataView(dtWord);
    // filter dataview and show in grid
    if (cboLanguage.Text == "Bangla")
     {
       wordlistview.RowFilter = "bangla LIKE '" + txtSearchValue.Text.Trim().ToUpper() + "%'";
     }
    else
    {
     wordlistview.RowFilter = "english LIKE '" + txtSearchValue.Text.Trim().ToUpper() +    "%'";
    }   
     GridWord.DataSource = wordlistview;
     
