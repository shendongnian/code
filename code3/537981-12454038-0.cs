    [Bind(Exclude = "Financial_Years")]
        public class KPICreateFormViewModel
        {
    
            //Properties
            public KPI KPI { get; set; }
            public SelectList Financial_Years { get; private set; }
    
            FYRepository fyrepo = new FYRepository();
          public KPICreateFormViewModel(KPI kpi)
            {
                KPI = kpi;
                Financial_Years = new SelectList(fyrepo.GetFys(), "ID", "Financial_Year");
                
            }
    
        }
