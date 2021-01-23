    private void letsPaint(object sender, PaintEventArgs e) {             
      using (Pen blackpen = new Pen(Color.Black, 3)) {
        e.Graphics.DrawLine(blackpen, 
                            mouseClickedX, mouseClickedY, mouseMoveX, mouseMoveY);
      }
    }
