        /// <summary>
        /// Activate the validation mechanism, so every request DTO with an existing validator
        /// will be validated.
        /// </summary>
        /// <param name="appHost">The app host</param>
        public void Register(IAppHost appHost)
        {
            if (Enabled) return;
            Enabled = true;
            // use my class instead of ServiceStack.ServiceInterface.Validation.ValidationFilters
            var filter = new MyValidationFilters();
            appHost.RequestFilters.Add(filter.RequestFilter);
            appHost.ResponseFilters.Add(filter.RequestFilter);
        }
