    namespace SilverlightApplication
    {
        public partial class Page : UserControl
        {
            public Page()
            {
                InitializeComponent();
     
                HtmlPage.RegisterScriptableObject("Page", this);            
            }
     
            [ScriptableMember]
            public void UpdateDataGrid()
            {
                myDataGridItemsReload(); // your routine
            }
        }
    } 
