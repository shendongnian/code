    WindowsPrincipal myPrincipal=...;
    ...
    var identity=(WindowsIdentity)myPrincipal.Identity;
    var task=Task.Factory.StartNew(ident=>{
            var id=(WindowsIdentity)ident;
            using(var context=id.Impersonate())
            {
                //Work using the impersonated identity here
            }
            return id;
        },identity).
    .ContinueWith(r=>{
            var id = r.Result;
            using(var context=id.Impersonate())
            {
                //Work using the impersonated identity here
            }
    });
