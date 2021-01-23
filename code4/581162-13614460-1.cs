    var bindings = kernel.GetBindings(typeof(ICat)).ToList();
    foreach(var binding in bindings)
    {
         if (!binding.IsConditional)
              kernel.RemoveBinding(binding);
    }
    kernel.Bind<ICat>().To<Domestic>();
