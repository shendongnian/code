    private void BindGrid()
    {
        List<string> lst = new List<string>();
        lst.Add("A");
        lst.Add("D1");
        lst.Add("A2");
        lst.Add("A3");
        List<Test> tst = new List<Test>();
        Test t = new Test();
        t.ListValue = lst;
        t.ID = 1;
        tst.Add(t);
        lst = new MyList();
        lst.Add("B");
        lst.Add("B1");
        lst.Add("A2");
        lst.Add("B3");
        t = new Test();
        t.ListValue = lst;
        t.ID = 2;
        tst.Add(t);
        lst = new MyList();
        lst.Add("C");
        lst.Add("B1");
        lst.Add("C2");
        lst.Add("C3");
        t = new Test();
        t.ListValue = lst;
        t.ID = 3;
        tst.Add(t);
        ArrayList a = new ArrayList();
        try
        {
            var lst2 = (from b in tst
                        select new
                        {
                            b.ID,
                            col2 = string.Join(Environment.NewLine, b.ListValue.Where(x => x.StartsWith("A")).ToArray()),
                            col3 = string.Join(Environment.NewLine, b.ListValue.Where(x => x.StartsWith("B")).ToArray()),
                            col4 = string.Join(Environment.NewLine, b.ListValue.Where(x => x.StartsWith("C")).ToArray())
                        }).ToList();
            GridView1.DataSource = lst2;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            string ss = ex.Message;
        }
    }
    public class Test
    {
    public int ID { get; set; }
    public List<string> ListValue { get; set; }
    }
