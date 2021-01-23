    public void myMethod(List<TSource> y)
    int locationControl = 78;
        y.ForEach(x =>
        {
            KPIEntrys uc = new KPIEntrys();         // UserControl
            uc.KPI = x.KPI;                         // Add data to properties
            uc.Status = x.Status.ToString();
            uc.Goal = x.Goal.ToString();
            uc.Currently = x.Currently.ToString();
            bool checkaction = x.ShowAction == true ? uc.ShowAction = true : uc.ShowAction = false;
            bool checkstats = x.ShowStats == true ? uc.ShowStats = true : uc.ShowStats = false;
            bool checkstatus = x.Status < x.StatusSignal ? uc.StatusGood = true : uc.StatusGood = false;
            uc.Location = new Point(21, locationControl);
            this.Controls.Add(uc);                  // Add Control to Form
            locationControl = locationControl + 34;
        }
        );
