        public dynamic ViewBag
        {
            get
            {
                if (_dynamicViewData == null)
                {
                    _dynamicViewData = new DynamicViewDataDictionary(() => ViewData);
                }
                return _dynamicViewData;
            }
        }
