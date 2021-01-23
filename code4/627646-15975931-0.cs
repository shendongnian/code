        public IEnumerable<BarDto> SortedBars
        {
            get
            {
                if (Bars == null)
                    return null;
                return Bars.OrderBy(x => x.SortOrder).ToList();
            }
        }
