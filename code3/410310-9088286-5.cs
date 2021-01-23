    public partial class SkeletonManagerDialog : Form, IXnaFormContainer
    {        
        public Control XnaControl { get { return spriteBoneEditor1.XnaPicture; } }
        public XnaControlGame Game { get; set; }
        ....
    }
