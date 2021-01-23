    private void drawingSurface_Paintobject sender, PaintEventArgs e)
    {
        foreach (IObject o in _objects) {
            o.Paint(e.Graphics);
            if (o == _selectedObject) {
                foreach (IAdorner a in o.Adorners) {
                    a.Paint(e.Graphics);
                }
            }
        }
    }
