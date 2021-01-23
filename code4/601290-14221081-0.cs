    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var table = new Table() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Black, CellSpacing = 4 };
            var rowGroup = new TableRowGroup();
            var tableRow = new TableRow();
            var cell1 = new TableCell() { RowSpan = 1, Background = Brushes.Red, BorderThickness = new Thickness(3, 3, 3, 3), BorderBrush = Brushes.Green };
            var cell2 = new TableCell() { RowSpan = 1, Background = Brushes.Red, BorderThickness = new Thickness(2, 2, 2, 2), BorderBrush = Brushes.Blue };
            var correctContent = "**************************************************************************************************************************************************************************************************************************************";
            cell1.Blocks.Add(new Paragraph(new Run("Cell 1" + correctContent)));
            cell2.Blocks.Add(new Paragraph(new Run("Cell 2" + correctContent.Replace("*","   ")+".")));
            tableRow.Cells.Add(cell1);
            tableRow.Cells.Add(cell2);
            rowGroup.Rows.Add(tableRow);
            table.RowGroups.Add(rowGroup);
            var flowDocument = new FlowDocument();
            flowDocument.Blocks.Add(table);
            Content = flowDocument;
        }
    }
