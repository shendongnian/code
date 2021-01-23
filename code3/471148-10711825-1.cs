    Dictionary<int, string> dic = new Dictionary<int, string>();
    dic.Add(1, "ron k polito");
    dic.Add(2, "Ryan s Winslate");
    
    var dicNames = (from a in (dic.Select(b => b.Value).Select(c => c.Split(' ')).AsEnumerable()) select new CustomerName { FirstName = a[0], MidName = a[1], LastName = a[2] }).ToList();            
    
    dataGridView1.DataSource = dicNames;
