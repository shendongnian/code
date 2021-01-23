    case "StrategyRules":
    {
        switch (dbChange.Action)
        {
            case "D":
            {
                var removedStrategyRule = _strategy.StrategyRules
                    .SingleOrDefault(sr => sr.Id == dbChange.TablePK);
                if (removedStrategyRule != null)
                    _strategy.StrategyRules.Remove(removedStrategyRule);
            }
            break;
            case ...
        }
    }
    break;
