    public list sort(String order)
    {
         var list = new string[] { TextBox1.Text, TextBox2.Text, TextBox3.Text };
         var orderedlist = list.OrderByDescending(x => (x)).ToArray();
         ...
         SqlCommand cmd = new SqlCommand("Select * from lists order by values + order, conn)
         ...
         return SortedList;
    }
