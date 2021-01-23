    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public class ButtonPictureBox : PictureBox
        {
            protected override void OnDoubleClick(System.EventArgs e)
            {
                OnClick(e);
            }
        }
    }
