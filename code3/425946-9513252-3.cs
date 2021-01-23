    List<String> list = new List<String>();
    list.Add("Book  23");
    list.Add("Book  22");
    list.Add("Book 19");
    list.Add("Notebook  23");
    list.Add("Notebook  22");
    list.Add("Notebook  19");
    list.Add("Pen  23");
    list.Add("Pen  22");
    list.Add("Pen  19");
    list.Add("sheet 3");
    var q = from str in list
            let Parts = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            let item = Parts[ 0 ]
            let num = int.Parse(Parts[ 1 ])
            group new  { Name = item, Number = num } by item into Grp
            select new {
                Name  = Grp.Key,
                Value = Grp.Max(i => i.Number).ToString()
            };
    var highestGroups = q.Select(g => String.Format("{0} {1}", g.Name, g.Value));
    MessageBox.Show(String.Join(Environment.NewLine, highestGroups));
