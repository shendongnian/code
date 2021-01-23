    public class PropertySetActionProvider<TObj, TProp>
    {
        private Func<TObj, TProp> _getter;
        private Action<Tbj, TProp> _setter;
        public PropertySetActionProvider(Expression<Func<TObj, TProp>> propertySelector)
        {
            _getter = propertySelector.Compile();
            _setter = SetterExpressionFromGetterExpression(propertySelector).Compile(); 
        }
        public IUndoRedoAction CreateAction(TObj target, TProp newValue)
        {
            var oldValue = _getter(target);
            return new PropertySetAction<TObj, TProp>(_setter, target, oldValue, newValue);             
        }
    }
    
    public class PropertySetAction<TObj, TProp> : IUndoRedoAction 
    {
       private Action<TObj, TProp> _setter;
       private TObj _target;
       private TProp _oldValue;
       private TProp _newValue;
       
       public PropertySetAction(Action<TObj, TProp> setter, TObj target, TProp oldValue, TProp newValue)
       {
            _setter = setter; 
            _target = target; 
            _oldValue = oldValue; 
            _newValue = newValue;
       }
   
       public void Do() 
       {
           _setter(_target, _newValue);
       }  
       public void Undo() 
       {
           _setter(_target, _oldValue);
       }   
    }
