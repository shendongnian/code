    public class DoNotUseSpecificEnum : RuleBase
    {
      private string[] _enumValsToCheck =
      {
        "APIEnum.Val2"
      };
      public DoNotUseSpecificEnum ()
        : base("DoNotUseSpecificEnum ") { }
      public override void VisitBinaryExpression(BinaryExpression binaryExpression)
      {
        if ( _enumValsToCheck.Contains(binaryExpression.Operand1.ToString()) || _enumValsToCheck.Contains( binaryExpression.Operand2.ToString() ) )
        {
          this.Problems.Add(new Problem(base.GetResolution(), binaryExpression.SourceContext));
        }
            base.VisitBinaryExpression(binaryExpression);
      }
    }
