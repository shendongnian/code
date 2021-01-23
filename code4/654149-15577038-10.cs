    class ViolationFinder : IViolationFinder
    {
        public IEnumerable<Violation> Search(IEnumerable<RuleDefinition> ruleDefinitions, IEnumerable<Request> requests)
        {
            var violations = new List<Violation>();
    
            foreach (RuleDefinition rule in ruleDefinitions)
            {
                violations.AddRange(FindViolationsInRequests(requests, rule));
            }
    
            return violations;
        }
    
        private IEnumerable<Violation> FindViolationsInRequests(
            IEnumerable<Request> allRequest,
            RuleDefinition rule)
        {
            foreach (Request firstRequest in FindMatchingRequests(allRequest, rule))
            {
    
                Request collidingRequest = FindCollidingRequest(allRequest, firstRequest, rule.MinimumDistanceBetweenRequests);
    
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
    
        private IEnumerable<Request> FindMatchingRequests(IEnumerable<Request> requests, RuleDefinition rule)
        {
            return requests.Where(r => r.TypeOfThisRequest == rule.ConcerningRequestType);
        }
    
        private Request FindCollidingRequest(IEnumerable<Request> requests, Request firstRequest, int minimumDistanceBetweenRequests)
        {
            return requests.FirstOrDefault(secondRequest => IsCollidingRequest(firstRequest, secondRequest, minimumDistanceBetweenRequests));
        }
    
        private bool IsCollidingRequest(Request firstRequest, Request secondRequest, int minimumDistanceBetweenRequests)
        {
            return secondRequest.TimeIndex > firstRequest.TimeIndex &&
                   Math.Abs(secondRequest.TimeIndex - firstRequest.TimeIndex) < minimumDistanceBetweenRequests;
        }
    }
