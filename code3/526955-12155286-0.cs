    public static void DrawBorderOnFocused(this Control control)
    {
        if(control == null) throw new ArgumentNullException("control");
        control.Paint += OnControlPaint;
    }
    public static void OnControlPaint(object sender, PaintEventArgs e)
    {
        var control = (Control)sender;
        if(control.Focused)
        {
           var graphics = e.Graphics;
           var bounds = e.Graphics.ClipBounds;
           // ToDo: Draw the desired shape above the current control
           graphics.DrawLine(Pens.BurlyWood, new PointF(bounds.Left, bounds.Top), new PointF(bounds.Bottom, bounds.Right));
        }
    }
