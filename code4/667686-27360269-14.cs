    /// <summary>
    /// Pomocná třída pro tvorbu AjaxTable a detekci konce tabulky v cshtml šabloně
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AjaxTableDisposable<T> : IDisposable where T : new()
    {
        private HtmlHelper htmlHelper;
        private ViewContext viewContext;
        private AjaxTable<T> table;
        public AjaxTableDisposable(HtmlHelper htmlHelper, IQueryable<T> items, string ajaxUrl, RouteValueDictionary attrs)
        {
            // akce na zacatku
            this.htmlHelper = htmlHelper;
            viewContext = htmlHelper.ViewContext;
            viewContext.TempData["AjaxTable"] = this;
            if (!attrs.ContainsKey("id")) attrs["id"] = "AjaxTable" + Guid.NewGuid().ToString("N");
            table = new AjaxTable<T>() { AjaxUrl = ajaxUrl, Attrs = attrs, Items = items };
        }
        public void Column<TKey>(Func<T, HelperResult> th, Func<T, HelperResult> td, Expression<Func<T, TKey>> keySelector)
        {
            AjaxTableColumn<T> col = new AjaxTableColumn<T>() { Th = th, Td = td, KeySelector = keySelector, KeyType = typeof(TKey) };
            col.OrderData = (IQueryable<T> data, bool asc) => asc ? data.OrderBy(keySelector) : data.OrderByDescending(keySelector);
            table.Columns.Add(col);
        }
        // When the object is disposed (end of using block), write "end" function
        public void Dispose()
        {
            // akce na konci
            viewContext.TempData.Remove("AjaxTable");
            viewContext.Writer.Write(htmlHelper.Partial("DisplayTemplates/AjaxTable", table));
            string tableId = table.Attrs["id"].ToString();
            StoreInSession(table);  // TODO: you have to implement the StoreInSession method
        }
    }
