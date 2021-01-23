      public static class FunctionClass
            {
        private void NewBtn(string nName, int locX, int locY)
        {
        //Your Action
        }
        private void NewPic(string nName, int locX, int locY, int SizX, int SizY, Image Img)
        {
        //Your Action
        }
        }
    
    public partial class SecondForm: Form
            {
        public SecondForm()
                {
       FunctionClass.NewBtn(Arguments);
        }
        }
