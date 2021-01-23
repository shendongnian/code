    class Condition
    {
        public string ConditionString{get;set;}
        public Condition ParentCondition{get;set;}
        public List<Condition> ChildConditions{get;set;} // in case there are more 
                                                            than one conditions.
    }
