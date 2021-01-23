    public partial class MainForm : Form
    {
            readonly KeyboardFilter kbFilter = new KeyboardFilter(new Keys[] 
            { 
                Keys.LWin | Keys.D,
                Keys.RWin | Keys.D, 
                Keys.LWin | Keys.X, 
                Keys.RWin | Keys.X,
                Keys.Alt | Keys.F4
            });
    }
