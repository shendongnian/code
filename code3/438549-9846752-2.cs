    public class GoGreenButtonDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public override void OnSetComponentDefaults()
        {
            base.OnSetComponentDefaults();
            Control.Text = "Go Green";
        }
    }
