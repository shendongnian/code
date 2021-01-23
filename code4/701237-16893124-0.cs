    var rules = dgRulesMaster.Rows
                             .Select(x => new {
                                         RuleId = x.Cells[0].Value.ToString(),
                                         IsWarning = x.Cells[3].Value.ToString() });
    var tuples = from n in xdoc.Descendants("Rule")
                 from r in rules
                 where n.Attribute("id").Value == r.RuleId
                 select new { Node = n, Rule = r };
    
    foreach(var tuple in tuples)
        tuple.Node.Attribute("action").Value = tuple.Rule.IsWarning;
