    private void gridview_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      int r = e.RowIndex;
      llenartextbox(r);
    }
       
    public void llenartextbox(int index)
    {
      textbox.Text = gridview.rows[index].Cells["Cliente"].Value.ToString();
    }
