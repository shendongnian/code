    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
    private void GenerateButton_Click(object sender, EventArgs e)
    {
        OutputTextBox.Clear();
        OutputTextBox.Text += "A\tB\tC\r\n";
        OutputTextBox.Text += GetHorizontalLineText();
        var myTruthTable = GenerateTruthTable().ToList();
        foreach(var item in myTruthTable)
        {
            OutputTextBox.Text += GetFormattedItemText(item);
            OutputTextBox.Text += GetHorizontalLineText();
        }
    }
    private void ShowTrueValuesButton_Click(object sender, EventArgs e)
    {
        OutputTextBox.Clear();
        OutputTextBox.Text += "True Values\r\n";
        OutputTextBox.Text += "A\tB\tC\r\n";
        OutputTextBox.Text += GetHorizontalLineText();
        
        var myTruthTable = GenerateTruthTable().ToList();
        foreach(var item in myTruthTable)
        {
            if(item.GetTruthValue())
                OutputTextBox.Text += GetFormattedItemText(item);
        }
    }
    private static string GetHorizontalLineText()
    {
        return "-----------------------------------------------\r\n";
    }
    private static string GetFormattedItemText(MyCustomThreeItemTruthRow item)
    {
        return string.Format("{0}\t{1}\t{2}\r\n", item.A, item.B, item.C);
    }
    private static IEnumerable<MyCustomThreeItemTruthRow> GenerateTruthTable()
    {
        for (var a = 0; a < 2; a++)
            for (var b = 0; b < 2; b++)
                for (var c = 0; c < 2; c++)
                    yield return new MyCustomThreeItemTruthRow(
                        Convert.ToBoolean(a),
                        Convert.ToBoolean(b),
                        Convert.ToBoolean(c));
        }
    }
