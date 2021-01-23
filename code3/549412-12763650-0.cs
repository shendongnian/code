    using (var conn = new SqlConnection("Data Source=MAZI-PC\\PROJECTACC;Initial Catalog=programDB;Integrated Security=True"))
    {
        var sql = "select label_sh from label_text where label_form_labelID IN('1','2','3') and label_form='2'";
        using (var da = new SqlDataAdapter(sql, conn))
        {
            da.Fill(table); // you don't need to open a connection when using a DataAdapter
        }
    }
    label1.Text = table.AsEnumerable()
                       .Single(r => r.Field<int>("label_form_labelID") == 1)
                       .Field<String>("label_sh");
    label2.Text = table.AsEnumerable()
                       .Single(r => r.Field<int>("label_form_labelID") == 2)
                       .Field<String>("label_sh");
    label3.Text = table.AsEnumerable()
                      .Single(r => r.Field<int>("label_form_labelID") == 3)
                      .Field<String>("label_sh");
