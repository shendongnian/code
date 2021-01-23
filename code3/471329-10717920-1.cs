    public override void CalcV(IV iv, int? index = null)
    {
         initializations
         otherOperations
    
         for (int i=0; i < NUM; ++i)
         {
             SomeOtherOperations
             double v = index != null ? GetV(a,b,c, index) : GetV(a,b,c);
             SomeOtherOperationsUsing_v
         }
    
         restOfOperations
    }
