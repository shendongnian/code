    public class GMapControlFixed : GMapControl
    {
        public override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
            }
            catch(ArgumentOutOfRangeException)
            {
                // discard - it's a bug in the original control.
            }
        }
    }
