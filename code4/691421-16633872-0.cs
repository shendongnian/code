    Kend._2013.Extension.KendoGrid<string>.Name("KendoGrid1")
                                              .Columns(c => new Kend._2013.Extension.Column[]
                                              {                                                                                   
                                                    c.Add("ProductID").Title("ID").Width(100),
                                                    c.Add("ProductName").Title("Name").Width(150),
                                                    c.Add("UnitPrice").Title("Price").Width(150),
                                                    c.Add("Discontinued").Title("Amount").Width(150),
                                                    c.Add("UnitsInStock").Title("Units In").Width(150),                                           
                                              });
        namespace Kend._2013.Extension
    {
        public class Column
        {
            private string fieldName;
            private string title;
            private int width;
            private int height;
    
            private readonly Column previous;
        private Column(Column previous)
        {
            this.previous = previous;
        }
        public Column Add(string name)
        {
            this.fieldName = name;
            return new Column(this);
        }
        public Column Title(string t)
        {
            this.title = t;
            return new Column(this);
        }
        public Column Width(int w)
        {
            this.width = w;
            return new Column(this);
        }
        public Column Height(int h)
        {
            this.height = h;
            return new Column(this);
        }
    }
    public class KendoGridDataSource
    {
    }
    public class KendoGrid<T>
    {
        private readonly T target;
        private readonly KendoGrid<T> previous;
        private KendoGrid(T target, KendoGrid<T> previous)
        {
            this.target = target;
            this.previous = previous;
        }
        public static KendoGrid<T> Name(T target)
        {
            return new KendoGrid<T>(target, null);
        }
        private bool isFitInPage;
        private int height;
        private int width;
        private Column columns;
        private bool pageable;
        private bool sortable;
        private bool filterable;
        private bool editable;
        private string uICulture;
        private bool showContextMenu;
        private bool showFilterMenu;
        private bool showGroupArea;
        private bool showToolbars;
        private KendoGridDataSource DataSource;
        private bool DataBatching;
        private void FitToPage(bool b)
        {
            this.isFitInPage = b;
        }
        public KendoGrid<T> Height(int h)
        {
            this.height = h;
            return new KendoGrid<T>(target, this);
        }
        public KendoGrid<T> Width(int w)
        {
            this.width = w;
            return new KendoGrid<T>(target, this);
        }
        public KendoGrid<T> Pageable(bool pageable)
        {
            this.pageable = pageable;
            return new KendoGrid<T>(target, this);
        }
        public KendoGrid<T> Sortable(bool sortable)
        {
            this.sortable = sortable;
            return new KendoGrid<T>(target, this);
        }
        public KendoGrid<T> Filterable(bool filterable)
        {
            this.filterable = filterable;
            return new KendoGrid<T>(target, this);
        }
        public KendoGrid<T> Editable(bool editable)
        {
            this.editable = editable;
            return new KendoGrid<T>(target, this);
        }
        public KendoGrid<T> ShowContextMenu(bool show)
        {
            this.showContextMenu = show;
            return new KendoGrid<T>(target, this);
        }
        public KendoGrid<T> ShowFilterMenu(bool show)
        {
            this.showFilterMenu = show;
            return new KendoGrid<T>(target, this);
        }
        public KendoGrid<T> ShowGroupArea(bool show)
        {
            this.showGroupArea = show;
            return new KendoGrid<T>(target, this);
        }
        public KendoGrid<T> ShowToolbars(bool show)
        {
            this.showToolbars = show;
            return new KendoGrid<T>(target, this);
        }
        public KendoGrid<T> Columns(Expression<Func<Column, Column>> col)
        {           
            var a = col.Compile();
            Column c = new Column();
            a(c);
            return new KendoGrid<T>(target, this);
        }
        public void Render(){ // write html }
      }
    }
