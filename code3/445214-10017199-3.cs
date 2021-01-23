        listView1.View=View.Details;
        listView1.Columns.Add("Name");
        listView1.Columns.Add("Number");
        Record[] list=new Record[] {
            new Record() { name="Abraham", number=1018001 },
            new Record() { name="Buster", number=1027400 },
            new Record() { name="Charlie", number=1028405 }
        };
        for(int i=0; i<list.Length; i++)
        {
            listView1.Items.Add(
                new ListViewItem(list[i].ToStringArray()));
        }
