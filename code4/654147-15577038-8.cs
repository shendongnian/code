    class ViolationFinder : IViolationFinder
    {
        public IEnumerable<Violation> Search(IEnumerable<RuleDefinition> ruleDefinitions, IEnumerable<Request> requests)
        {
            var violations = new List<Violation>();
            foreach (RuleDefinition rule in ruleDefinitions)
            {
                IEnumerable<Request> requestsMatchingType = requests.Where(r => r.TypeOfThisRequest == rule.ConcerningRequestType);
                violations.AddRange(
                    FindViolationsInRequests(requestsMatchingType, requests, rule));
            }
    
            return violations;
        }
    
        private IEnumerable<Violation> FindViolationsInRequests(
            IEnumerable<Request> matchingRequests,
            IEnumerable<Request> allRequest,
            RuleDefinition rule)
        {
            foreach (Request firstRequest in matchingRequests)
            {
                var collidingRequest = allRequest.FirstOrDefault(secondRequest =>
                    secondRequest.TimeIndex > firstRequest.TimeIndex &&
                    Math.Abs(secondRequest.TimeIndex - firstRequest.TimeIndex) < rule.MinimumDistanceBetweenRequests);
    
                if (collidingRequest != null)
                {
                    yield return new Violation
                    {
                        ViolatedRule = rule,
                        FirstRequest = firstRequest,
                        SecondRequest = collidingRequest
                    };
                }
            }
        }
    }
