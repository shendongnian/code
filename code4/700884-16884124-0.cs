    public void drawMonomers(Graphics g, Point location, string state) {
       // Etc...
    }
    private void Display1_Paint(object sender, PaintEventArgs e) {
       //...
       drawMonomers(e.Graphics, loc, state);
    }
