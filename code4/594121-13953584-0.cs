        [StepArgumentTransformation]
        public Mock<MyData> MockMyDataTransform(Table table)
        {
            MyData myData = new Mock<MyData>();
            var row = table.Rows[0];
            if (table.ContainsColumn("MyField"))
            {
                myData.Setup(x=>x.MyField).Returns(row["MyField"]);
            }
         ....
        }
