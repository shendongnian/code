    public class BlogEntyTreeItem
{
    public string Text { set; get; }
    public string URL { set; get; }
    public List<BlogEntyTreeItem> Children { set; get; }
    public List<BlogEntyTreeItem> GetTree()
    {
        NWDataContext db = new NWDataContext();
        var p = db.Posts.ToList();
        var list = p.GroupBy(g => g.DateCreated.Year).Select(g => new BlogEntyTreeItem
        {
            Text = g.Key.ToString(),
            Children = g.GroupBy(g1 => g1.DateCreated.ToString("MMMM")).Select(g1 => new BlogEntyTreeItem
            {
                Text = g1.Key,
                Children = g1.Select(i => new BlogEntyTreeItem { Text = i.Name }).ToList()
            }).ToList()
        }).ToList();
        return list;        
    }
