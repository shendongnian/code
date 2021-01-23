    public partial class WizardStepControl : UserControl
    {
        public WizardStepControl()
        {
            InitializeComponent();
        }
        public void SetStepCurrent(int step)
        {
            switch (step)
            {
                case 1:
                    SetCurrent(step1);
                    break;
                case 2:
                    SetCurrent(step2);
                    break;
                case 3:
                    SetCurrent(step3);
                    break;
            }
        }
        public void SetStepChecked(int step)
        {
            switch (step)
            {
                case 1:
                    SetChecked(step1);
                    break;
                case 2:
                    SetChecked(step2);
                    break;
                case 3:
                    SetChecked(step3);
                    break;
            }
        }
        public void SetStepNext(int step)
        {
            switch (step)
            {
                case 1:
                    SetNext(step1);
                    break;
                case 2:
                    SetNext(step2);
                    break;
                case 3:
                    SetNext(step3);
                    break;
            }
        }
        private void SetChecked(CheckEdit checkBox)
        {
            checkBox.Enabled = true;
            checkBox.Properties.PictureChecked = Resources.wzd_check;
            checkBox.Properties.PictureUnchecked = Resources.wzd_check;
            checkBox.Properties.PictureGrayed = Resources.wzd_check;
        }
        private void SetNext(CheckEdit checkBox)
        {
            checkBox.Enabled = false;
            checkBox.Properties.PictureChecked = Resources.wzd_next;
            checkBox.Properties.PictureUnchecked = Resources.wzd_next;
            checkBox.Properties.PictureGrayed = Resources.wzd_next;
        }
        private void SetCurrent(CheckEdit checkBox)
        {
            checkBox.Enabled = true;
            checkBox.Properties.PictureChecked = Resources.wzd_current;
            checkBox.Properties.PictureUnchecked = Resources.wzd_current;
            checkBox.Properties.PictureGrayed = Resources.wzd_current;
        }
    }
