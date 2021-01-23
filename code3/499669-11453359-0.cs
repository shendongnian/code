    if (mail != null)
    {
        foreach (Outlook.Rule rule in rules)
        {
           foreach (Outlook.RuleCondition condition in rule.Conditions)
           {
             if (condition is TextRuleCondition)
             {
                Outlook.TextRuleCondition trc = condition as Outlook.TextRuleCondition;
                if (trc.ConditionType == Outlook.OlRuleConditionType.olConditionSubject)
                {
                  // TODO: handle Rule.Exceptions conditions
                  bool containsSubject = mail.Subject.Contains(trc.Text);
                }
             }
           }
        }
    }
