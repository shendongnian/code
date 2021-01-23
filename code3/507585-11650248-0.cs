    public class MyData {
        public int AA { get; set; }
        public string Description { get; set; }
        ...
    }
    ...
    l1.Items.Add(new MyData { AA = aa++, Description = descriptions[k], ...});
    ...
    MyData b = (MyData) l1.Items.GetItemAt(0);
    int aaValueOfB = b.AA;
