    private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                int numOfCells = 200;
                int cellSize = 5;
                Pen p = new Pen(Color.Black);
    
                for (int y = 0; y < numOfCells; ++y)
                {
                    g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
                }
    
                for (int x = 0; x < numOfCells; ++x)
                {
                    g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
                }
            }
    
