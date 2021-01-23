    public bool RuleCausesCycle(Rule rule)
    {
        return RuleCausesCycle(rule, new HashSet(CaseInsensitiveComparer.Default));
    }
    private bool RuleCausesCycle(Rule rule, Set visited)
    {
         Rule targetRule;
         if (visited.Contains(rule.sourceDir))
         {
             return true;
         }
         if (rules.TryGetValue(rule.targetDir, out targetRule))
         {
             visited.Add(rule.sourceDir);
             return RuleConflicts(targetRule, visited);
         }
         return false;
    }
