    public class GravCalc
    {
        private ControlType _control1;
        private ControlType _control2;
        public GravCalc(ControlType control1, ControlType control2)
        {
            _control1 = control1;
            _control2 = control2
        }
        private static float engineer = 1.0f;
        public void ShowEngineer()
        {
            GravCalc.engineer = 1.1f;
            gravEngineerLabel.Visible = true;
            gravEngineerLine.Visible = true;
        }
    };
