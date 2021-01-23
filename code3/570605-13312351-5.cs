        private void pnlCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }
        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (pointListe.Count > 1)
            {
                e.Graphics.DrawLines(new Pen(color), pointListe.ToArray());
            }
        }
    }
