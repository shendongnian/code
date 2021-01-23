    //the sample data as provided by the OP
    var rules = new []
    {
        new { ItemId = "ItemA", RuleId = "RuleA", IsActive = false },
        new { ItemId = (string)null, RuleId = "RuleA", IsActive = true },
        new { ItemId = "ItemC", RuleId = "RuleA", IsActive = true },
        new { ItemId = "ItemA", RuleId = "RuleB", IsActive = false },
        new { ItemId = (string)null, RuleId = "RuleB", IsActive = true },
    };
    
    //the items that we want to get the rules for
    var items = new [] { "ItemA", "ItemB", "ItemC", };
    
    //get the rules for all of the items
    var query = from i in items
                let itemRules = from r in rules
                                //we need to prefer rules that match our id
                                orderby r.ItemId ?? "" descending
                                //match on id or null
                                where (r.ItemId ?? i) == i                            
                                group r by r.RuleId into grouping                        
                                //take the best match
                                select grouping.First()
                select new
                {
                    i,
                    itemRules,
                };
