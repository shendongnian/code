     public partial class BaseForm: Form
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
    
    public partial class SecondForm: BaseForm
        {
    public SecondForm()
            {
    NewPic(Parameters);
    }
    }
