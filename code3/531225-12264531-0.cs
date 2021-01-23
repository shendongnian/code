    public class Form1
    {
        public new DialogResult ShowDialog()
        {
            Init();
            return base.ShowDialog();
        }
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            Init();
            return base.ShowDialog(owner);
        }
        public void Init()
        {
            // code goes here
        }
    }
