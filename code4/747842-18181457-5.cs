    private void dataGridView1_Scroll(object sender, ScrollEventArgs e){
      Point p = dataGridView1.PointToClient(MousePosition);
      if (dataGridView1.HitTest(p.X, p.Y).Type == DataGridViewHitTestType.VerticalScrollBar){
         //Your code here
      }
    }
