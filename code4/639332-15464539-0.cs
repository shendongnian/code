    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                elementHost1.HostContainer.MouseEnter += new System.Windows.Input.MouseEventHandler(HostContainer_MouseEnter);
            }
            void HostContainer_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
            {
                MessageBox.Show("Mouse entered");
            }
    
        }
