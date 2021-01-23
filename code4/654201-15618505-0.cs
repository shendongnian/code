    public partial class StatusPickerPopoverView : UIViewController
    {
        public StatusPickerPopoverView (IntPtr handle) : base (handle)
        {
        }
        public override ViewDidLoad()
        {
            base.ViewDidLoad();
            pickerStatus = new UIPickerView();
            pickerStatus.Model = new StatusPickerViewModel();
        }
        public class StatusPickerViewModel : UIPickerViewModel
        {
            public override int GetComponentCount (UIPickerView picker)
            {
                return 1;
            }
            public override int GetRowsInComponent (UIPickerView picker, int component)
            {
                return 5;
            }
            public override string GetTitle (UIPickerView picker, int row, int component)
            {
                return "Component " + row.ToString();
            }
        }
    }
