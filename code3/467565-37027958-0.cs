    public class NoNullsInjection : LoopInjection
    {
        protected override void SetValue(object source, object target, PropertyInfo sp, PropertyInfo tp)
        {
            if (sp.GetValue(source) == null) return;
            base.SetValue(source, target, sp, tp);
        }
    }
