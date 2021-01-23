            Uri uri = new Uri(@"C:\d1.jpg");
            BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage(uri);
            ...
            DataGrid dg = new DataGrid();
            dg.AutoGenerateColumns = false;
            DataGridTemplateColumn col1 = (DataGridTemplateColumn)this.FindResource("dgt");
            dg.Columns.Add(col1);
            DataGridTextColumn col2 = new DataGridTextColumn();
            col2.Header = "Column2";
            col2.Binding = new Binding("Column2");
            dg.Columns.Add(col2);
            ...
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1", typeof(BitmapImage));
            dt.Columns.Add("Column2");
            DataRow dr = dt.NewRow();
            dr[0] = bmp;
            dr[1] = "test";
            dt.Rows.Add(dr);
            ...
            dg.ItemsSource = dt.DefaultView;
            grid1.Children.Add(dg);
