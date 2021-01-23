    class Calculate
    {
        private QuoteViewModel _quoteData;
        private PriceQuote _prices;
        public Calculate(QuoteViewModel quoteData, PriceQuote prices)
        {
            _quoteData = quoteData;
            _prices = prices;
        }
        public decimal SpouseFilingChapter7
        {
            get
            {
                if (_quoteData.QuotePartRecord.MaritalStatusDropDown == MaritalStatus.Yes)
                {
                    return _quoteData.QuotePartRecord.SpouseFilingRadioButton == SpouseFiling.Yes ?
                        _prices.priceSpouseFilingChapter7 :
                        _prices.priceNoSpouseFilingChapter7;
                }
                else
                    return 0;
            }
        }
        public decimal TotalChapter7
        {
            get
            {
                return _prices.priceChapter7 +
                    SpouseFilingChapter7 +
                    PaymentPlanChapter7 +
                    ProcessingChapter7 +
                    SubmissionChapter7 +
                    DistrictChapter7 +
                    UnsecuredCreditor +
                    Garnishment +
                    TaxLiability +
                    RentalEviction +
                    RealEstateChapter7 +
                    RealEstateIntention +
                    VehicleChapter7 +
                    VehicleIntention +
                    OtherAssetChapter7 +
                    OtherAssetIntention +
                    FinancialAccount +
                    MeansTestAnalysisChapter7;
            }
        }
    }
