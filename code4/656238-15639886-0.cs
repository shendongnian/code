    namespace Keyboards
    {
    public class MyControl : Control
    {
    
    privare MyForm myForm {get; set;}
    //Parameterized Constructor
    public MyControl(MyForm myForm)
    {
    this.myForm = myForm;
    }
       private void HandlingMouseClick(Point PressedItem)
            {
                switch (ItemBtn._KeysType)
                        {
                            case Keys.Backspace:
                            SendKeys.Send("{BACKSPACE}");
                            break;
                            case Keys.D0:
                            // I would like to DoSomething(); or btnOK_Click
        myForm.DoSomething();
                            break;
                        }
            }
    }
     }
