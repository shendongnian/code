    public class UnflatLoopValueInjectionUseExactMatchIfPresent : UnflatLoopValueInjection {
        protected override void Inject(object source, object target) {
            var targetProperties = target.GetProps().Cast<PropertyDescriptor>().AsQueryable();
            foreach (PropertyDescriptor sourceProp in source.GetProps()) {
                var prop = sourceProp;
                if (targetProperties.Any(p => p.Name == prop.Name)) {
                    //Exact match found
                    targetProperties.First(p => p.Name == prop.Name).SetValue(target, SetValue(sourceProp.GetValue(source)));
                }
                else {
                    //Fall back to UnflatLoopValueInjection
                    var endpoints = UberFlatter.Unflat(sourceProp.Name, target, t => TypesMatch(prop.PropertyType, t)).ToList();
                    if (!endpoints.Any()) {
                        continue;
                    }
                    var value = sourceProp.GetValue(source);
                    if (!AllowSetValue(value)) {
                        continue;
                    }
                    foreach (var endpoint in endpoints) {
                        endpoint.Property.SetValue(endpoint.Component, SetValue(value));
                    }
                }
            }
        }
    }
