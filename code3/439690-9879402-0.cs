    struct ReportInfo
    {
        public string Name { get; set; }
        public Action Method { get; set; }
    }
    //...
    MyArray[0] = new ReportInfo { Name = "Daily_Unload", Action = this.reportDailyUnload };
    //...
    if(this.cboSelectReport.Text == MyArray[i].Name)
    {
        MyArray[i].Method.Invoke();
    }
