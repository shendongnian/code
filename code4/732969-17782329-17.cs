    private delegate object GetCallback(ListViewItem row);
    private object o;
    
    ...
    
    GetCallback g = new GetCallback(GetText);
                            o = this.Invoke(g, new object[] { row });
        private string GetText(ListViewItem row)
        {
            return row.SubItems[0].Text;
        }
