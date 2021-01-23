public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    <b>private void MaskNumericInput(object sender, TextCompositionEventArgs e)</b>
    {
        e.Handled = !TextIsNumeric(e.Text);
    }
    <b>private void MaskNumericPaste(object sender, DataObjectPastingEventArgs e)</b>
    {
        if (e.DataObject.GetDataPresent(typeof(string)))
        {
            string input = (string)e.DataObject.GetData(typeof(string));
            if (!TextIsNumeric(input)) e.CancelCommand();
        }
        else
        {
            e.CancelCommand();
        }
    }
    <b>private bool TextIsNumeric(string input)</b>
    {
        return input.All(c => Char.IsDigit(c) || Char.IsControl(c));
    }
}
