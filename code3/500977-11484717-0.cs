    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
    imageColumn .Name = "ImageColumn";
    imageColumn .HeaderText = "An Image!";
    Image i = Image.FromFile(@"C:\Pictures\TestPicture.jpg");
    imageColumn.Image = i;
    dataGridView1.Columns.Add(imageColumn);
