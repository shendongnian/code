    public partial class Form1 : Form
    {
    DataSet _dataset;
    public Form1(DataSet dataSet)
    {
        _dataset = dataset;
        InitializeComponent();
    }
    //..
    public partial class Form2 : Form
    {
    DataSet _dataset;
    public Form2(DataSet dataSet)
    {
        _dataset = dataset;
        InitializeComponent();
    }
    //..
    
    static class Program
    {
        static void Main()
        {
            DataSet DS = new DataSet();
            Application.Run(new Form1(DS));
        }
    }
