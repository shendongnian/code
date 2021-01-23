    public void RuleSet(string ruleSetName, Func<List<IRuleBuilderOptions<T, object>>> function, Action<IRuleBuilderOptions<T, object>> writeRuleMessage)
    {
        ruleSetName.Guard("A name must be specified when calling RuleSet.");
        function.Guard("A ruleset definition must be specified when calling RuleSet.");
        using (nestedValidators.OnItemAdded(r => r.RuleSet = ruleSetName))
        {
            var list = function();
  
            foreach (var rule in list)
            {
                writeRuleMessage(rule);
            }
        }
    }
