    StringBuilder sb = new StringBuilder();
    foreach(ListViewItem item in ListView1.Items)
    {
         sb.Append(item.Text);
         sb.Append(',');
    }
    
    Console.WriteLine(sb.ToString().TrimEnd(','));
