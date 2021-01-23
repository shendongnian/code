            dynamic obj = new ExpandoObject();
            obj.FirsName = "John";
            obj.LastName = "Doe";
            var x = obj as IDictionary<string, Object>;
            for (int i = 0; i < 3; i++)
            {
                x["ReceivedMail_" + i] = true;
            }
            var data = new List<ExpandoObject>() { obj };
            this.dataGridView1.DataSource = data.ToDataTable();
