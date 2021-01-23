    class ViolationFinder : IViolationFinder
    {
        public IEnumerable<Violation> Search(IEnumerable<RuleDefinition> ruleDefinitions, IEnumerable<Request> requests)
        {
            var violations = new List<Violation>();
            foreach (var rule in ruleDefinitions)
            {
                var requestsMatchingType = requests.Where(r => r.TypeOfThisRequest == rule.ConcerningRequestType);
                foreach (var firstRequest in requestsMatchingType)
                {
                    var collidingRequest = requests.FirstOrDefault(secondRequest =>
                        secondRequest.TimeIndex > firstRequest.TimeIndex &&
                        Math.Abs(secondRequest.TimeIndex - firstRequest.TimeIndex) < rule.MinimumDistanceBetweenRequests);
    
                    if (collidingRequest != null)
                    {
                        violations.Add(new Violation
                        {
                            ViolatedRule = rule,
                            FirstRequest = firstRequest,
                            SecondRequest = collidingRequest
                        });
                    }
                }
            }
    
            return violations;
        }
    }
