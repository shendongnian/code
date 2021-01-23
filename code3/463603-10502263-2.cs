    public partial class BaseControl : UserControl
    {
        public BaseControl()
        {
            InitializeComponent();
        }
        protected Label[] Labels;
        public BaseControl(int num) : base()
        { 
            Labels = new Label[num]; 
            for(int i=0; i<num; i++) 
            { 
                Labels[i] = new Label(); 
            } 
        }
    }
    public class DerivedControl : BaseControl
    {
        public DerivedControl() : base(5)
        {
            Controls.Add(Labels[0]);
            Labels[0].Text = "Hello";
            Labels[0].Location = new System.Drawing.Point(10, 10);
        
        }
    
    }
