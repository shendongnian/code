        public List<_Category> GetTopLevelMenuItems() 
        { 
           entityName db = new entityName();
           var categories = db.Category.Where(x => x.CategoryID == null).Select(x => new _Category() { 
        ID = x.ID,
        CategoryName = x.CategoryName
        
        }).ToList();
        return categories;
        }
        public List<_Category> GetChildItems(_Category C)
        {
            entityName db = new entityName();
            var categories = db.Category.Where(x => x.CategoryID == C.ID).Select(x => new _Category()
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
            }).ToList();
            return categories;
        }
        public string BuildMenu()
        {
            List<_Category> menuItems = GetTopLevelMenuItems();
            string html = "<ul>";
            foreach (var menuItem in menuItems)
            {
                html += BuildMenuSubMenu(menuItem);
            }
            html += "</ul>";
            return html;
        }
        public string BuildMenuSubMenu(_Category menuItem)
        {
            string html = string.Empty;
            List<_Category> childItems = GetChildItems(menuItem);
            html += string.Format("<li><a href=\"{0}\">{1}</a>", menuItem.ID, menuItem.CategoryName);
            if (childItems.Count > 0)
            {
                html += "<ul>";
                foreach (var child in childItems)
                {
                    html += BuildMenuSubMenu(child);
                }
                html += "</ul>";
            }
            html += "</li>";
            return html;
        }
    public class _Category
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
