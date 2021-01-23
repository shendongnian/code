    //instead of this
    //dynamic dog2 = dog;    
    //try this
    dynamic dog2 = DynWrapper(dog);    
    String test2Result = dog2.Sound();//Now this works.
    public class DynWrapper : DynamicObject {
            private readonly object _target;
            public DynWrapper(object target) {
                _target = target;                
            }
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {   
                //for the sake of simplicity I'm not taking arguments into account,
                //of course you should in a real app.
                var mi = _target.GetType().GetMethod(binder.Name);
                if (mi != null) {
                    result = mi.Invoke(_target, null);                                        
                    return true;
                }
                return base.TryInvokeMember(binder, args, out result);
            }
        }
