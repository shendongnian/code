    abstract class AbstractControl { }
    class WinFormsControl : AbstractControl { }
    class WpfControl : AbstractControl { }
    interface IClientView
    {
       AbstractControl SelfControl { get; }
    }
