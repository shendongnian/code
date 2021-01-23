    public partial class MainForm : Form
    {
        //...
        List<DrawingObject> _objects = new List<DrawingObject>();
        private void PanelOne_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var o in _objects)
            {
                o.Draw(e.Graphics);
            }
        }
    }
