        private static List<DateRange> RangeTable
        {
            get
            {
                var result = new List<DateRange>() {
                    new DateRange() { fromDate = new DateTime(2012, 07, 01), toDate = new DateTime(2012, 07, 03) },
                    new DateRange() { fromDate = new DateTime(2012, 07, 05), toDate = new DateTime(2012, 07, 07) },
                    new DateRange() { fromDate = new DateTime(2012, 07, 10), toDate = new DateTime(2012, 07, 12) },
                    new DateRange() { fromDate = new DateTime(2012, 07, 13), toDate = new DateTime(2012, 07, 16) }
                };
                return result;
            }
        }
