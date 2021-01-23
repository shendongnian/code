        private void loadBtn_Click(object sender, EventArgs e)
        {
            string buffer = "1,2,3\r\n4,5,6\r\n7,8,9";
            TextFieldParser parser = new TextFieldParser(new MemoryStream(UTF8Encoding.Default.GetBytes(buffer)));
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            dataGridView1.Rows.Clear();
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                dataGridView1.Rows.Add(fields);
            }
        }
