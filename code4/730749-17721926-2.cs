    DataClasses1DataContext dc = new DataClasses1DataContext();
    this.Controls.AddRange(
        MyReusableMethod(
            dc.GTMD_Financials
                .Cast<IMyReusableInterface>()
                .ToList()
        )
    );
