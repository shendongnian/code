    internal enum SearchType
    {
        All = 0, Date = 1, Id = 2
    }
    public partial class MainForm : Form
    {
        private SearchType _selectedSearchType = SearchType.All;
        private void searchButton_Click(object sender, EventArgs e)
        {
            // Use _selectedSearchType to do search.
        }
        private void radioButton_Click(object sender, EventArgs e)
        {
            _selectedSearchType = (SearchType)Enum.Parse(typeof(SearchType), ((Control)sender).Tag.ToString());
        }
    }
