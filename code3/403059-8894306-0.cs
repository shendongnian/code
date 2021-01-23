        private void PopulateListView()
        {
            ListView1.Width = 300;
            ListView1.Location = new System.Drawing.Point(10, 50);
            // Declare and construct the ColumnHeader objects.
            ColumnHeader header1, header2;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
            // Set the text, alignment and width for each column header.
            header1.Text = "Column1"; //Helper.getlocalStringResource("Xinga.LocalStrings.ColumnHeader.ResourceValue");
            header1.Width = 100;
            header2.Text = "Column2"; //Helper.getlocalStringResource("Xinga.LocalStrings.ColumnHeader.ResourceValue");
            header2.Width = 100;
            // Add the headers to the ListView control.
            ListView1.Columns.Add(header1);
            ListView1.Columns.Add(header2);
            ListView1.View = View.Details;  //important to see the headers
        }
