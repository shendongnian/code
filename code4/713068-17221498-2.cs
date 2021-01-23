    public partial class SetupPanel : UserControl
    {
        public SetupPanel()
        {
            InitializeComponent();
        }
        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            AddParticipantGridViewColumns();
            base.OnRender(drawingContext);
        }
        public void AddParticipantGridViewColumns()
        {
            ...
            for (var blockIndex = 0; blockIndex < blockColumnCount; blockIndex++)
            {
                var column = BuildParticipantGridViewColumn(blockIndex);
                dataGrid.Columns.Add(column);
            }
        }
        private DataGridTemplateColumn BuildParticipantGridViewColumn(int blockIndex)
        {
            var columnXaml = string.Format(@"
                <DataGridTemplateColumn
                    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
                    Header=""Block {1}"">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text=""{{Binding BlockViewModels[{0}].ConditionLabel}}""
                                       Foreground=""{{Binding BlockViewModels[{0}].TextBrush}}"" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>",
                blockIndex, blockIndex + 1);
            var column = (DataGridTemplateColumn)XamlReader.Parse(columnXaml);
            return column;
        }
    }
