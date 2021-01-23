    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
          if (_dictionary.TryGetValue(binder.Name, out result)){
               if(result is Delegate && /* some reflection check on args*/){
                    result = ((dynamic)result)();
               }
          }
    }
