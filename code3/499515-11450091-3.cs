    var sinOperator = new UnaryOperator(childNode, Math.Sin);
        
    //In UnaryOperator Class
    public override double GetValue()
    {
         return _OpDelegate(_childNode.GetValue());
    }
