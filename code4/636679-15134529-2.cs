    private SectionObservable indicators = new SectionObservable(); // using the SectionObservable class instead 
    
            public SectionObservable Indicators // using the SectionObservable class instead 
            {
                get
                { 
                    return indicators;                
                }
            }
    
            private void IndicatorsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) // your suggestion
            {
                this.Invalidate();
            }
