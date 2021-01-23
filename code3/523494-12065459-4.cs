    using Microsoft.CSharp.RuntimeBinder;
    using System.Runtime.CompilerServices;
    ...
   
    dynamic o = MyNewObject();
    var binder = Binder.SetMember(CSharpBinderFlags.None,
    				   "Age",
    				   typeof(object),
    				   new List<CSharpArgumentInfo>{
    						   CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
    						   CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
    											   });
    
      var callsite = CallSite<Func<CallSite, object, object, object>>.Create(binder);
    
      callsite.Target(callsite,o,87);
    
      var binder2 =Binder.SetMember(CSharpBinderFlags.None,
    				   "Name",
    				   typeof(object),
    				   new List<CSharpArgumentInfo>{
    						   CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
    						   CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
    											   });
      var callsite2 = CallSite<Func<CallSite, object, object, object>>.Create(binder2);
    
      callsite2.Target(callsite2,o,"Sam");
      
