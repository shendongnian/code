    var dataSet = new DataSet();
    var blog = new DataTable("Blog");
    blog.Columns.Add("Title", typeof(string));
    blog.Columns.Add("Link", typeof(string));
    blog.Columns.Add("Comments", typeof(string));
    dataSet.Tables.Add(blog);
