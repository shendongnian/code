    public class TraceAspectProvider : IAspectProvider {
        readonly SomeTracingAspect aspectToApply = new SomeTracingAspect();
    
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement) {
            Assembly assembly = (Assembly)targetElement;
            List<AspectInstance> instances = new List<AspectInstance>();
            foreach (Type type in assembly.GetTypes()) {
                ProcessType(type, instances);
            }
            return instances;
        }
        void ProcessType(Type type, List<AspectInstance> instances) {
            foreach (MethodInfo targetMethod in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)) {
                instances.Add(new AspectInstance(targetMethod, aspectToApply));
            }
            foreach (Type nestedType in type.GetNestedTypes()) {
                ProcessType(nestedType, instances);
            }
        }
    }
