    public class MultiplicationTable
    {
        private const int columnWidth = 5;
        private string cellFormat = "{0, " + columnWidth + "}";
        private int columnsCount;
        private int rowsCount;      
        public MultiplicationTable(int columnsCount, int rowsCount)
        {
            this.columnsCount = columnsCount;
            this.rowsCount = rowsCount;
        }
        public void Draw()
        {            
            DrawColumnHeaders();
            DrawRaws();
        }
        private void DrawColumnHeaders()
        {
            string title = String.Format(cellFormat + "|", "x");
            Console.Write(title);
            for (int i = 1; i <= columnsCount; i++)
                Console.Write(cellFormat, i);
            Console.WriteLine();
            int tableWidth = columnWidth * columnsCount + title.Length;
            Console.WriteLine(new String('-', tableWidth));
        }
        private void DrawRaws()
        {
            for (int rowIndex = 1; rowIndex <= rowsCount; rowIndex++)
                DrawRaw(rowIndex);
        }
        private void DrawRaw(int rowIndex)
        {
            DrawRawHeader(rowIndex);
            for (int columnIndex = 1; columnIndex <= columnsCount; columnIndex++)
                DrawCell(rowIndex * columnIndex);
            Console.WriteLine();
        }
        private void DrawRawHeader(int rowIndex)
        {
            Console.Write(cellFormat + "|", rowIndex);
        }
        private void DrawCell(int value)
        {
            Console.Write(cellFormat, value);
        }
    }
