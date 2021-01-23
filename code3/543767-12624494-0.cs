    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
    
            flowLayoutPanel = new FlowLayoutPanel {
                Dock = DockStyle.Fill,
            };
            this.Controls.Add(flowLayoutPanel);
            // Add several sample UCs.
            for (int i = 0; i < 10; i++) {
                var uc = new UserControl1();
                uc.WasClicked += UsersGrid_WasClicked;
                flowLayoutPanel.Controls.Add(uc);
            }
        }
    
        FlowLayoutPanel flowLayoutPanel;
    
        // Event handler for when MouseClick is raised in a UserControl.
        void UsersGrid_WasClicked(object sender, EventArgs e) {
            // Set IsSelected for all UCs in the FlowLayoutPanel to false. 
            foreach (Control c in flowLayoutPanel.Controls) {
                if (c is UserControl1) {
                    ((UserControl1)c).IsSelected = false;
                }
            }
        }
    }
