    public class MyExcelDataObject
    {
        private readonly MyExcelData owner;
        private readonly object[,] realData;
        private int RealId;
        public MyExcelDataObject(MyExcelData owner, int index, object[,] realData)
        {
            this.owner = owner;
            this.realData = realData;
            ID = index;
            RealId = index;
        }
    
        public int ID { get; set; }
    
        public void DecrementRealId()
        {
            RealId--;
        }
    
        public string Column1
        {
            get { return (string)realData[RealId, 1]; }
            set
            {
                realData[ID, 1] = value;
                owner.Update(ID);
            }
        }
        public string Column2
        {
            get { return (string)realData[RealId, 2]; }
            set
            {
                realData[ID, 2] = value;
                owner.Update(ID);
            }
        }
        public string Column3
        {
            get { return (string)realData[RealId, 3]; }
            set
            {
                realData[ID, 3] = value;
                owner.Update(ID);
            }
        }
        public string Column4
        {
            get { return (string)realData[RealId, 4]; }
            set
            {
                realData[ID, 4] = value;
                owner.Update(ID);
            }
        }
    }
    
    public class MyExcelData : BindingList<MyExcelDataObject>
    {
        private Application excel;
        private Workbook wb;
        private Worksheet ws;
    
        private object[,] values;
    
        public MyExcelData(string excelFile)
        {
            excel = new ApplicationClass();
            excel.Visible = true;
            wb = excel.Workbooks.Open(excelFile);
            ws = (Worksheet)wb.Sheets[1];
    
            var range = ws.Range["A2", "D51"];
            values = (object[,])range.Value;
    
            AllowEdit = true;
            AllowRemove = true;
            AllowEdit = true;
    
            for (var index = 0; index < 50; index++)
            {
                Add(new MyExcelDataObject(this, index + 1, values));
            }
        }
    
        public void Update(int index)
        {
            var item = this[index - 1];
    
            var range = ws.Range["A" + (2 + index - 1), "D" + (2 + index - 1)];
            range.Value = new object[,]
                {
                    {item.Column1, item.Column2, item.Column3, item.Column4}
                };
        }
    
        protected override void RemoveItem(int index)
        {
            var range = ws.Range[string.Format("A{0}:D{0}", (2 + index)), Type.Missing];
            range.Select();
            range.Delete();
            base.RemoveItem(index);
    
            for (int n = index; n < Count; n++)
            {
                this[n].DecrementRealId();
            }
        }
    }
