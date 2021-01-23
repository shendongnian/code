    namespace ConsoleApplication
    {
        using System;
        using Ninject;
        using Ninject.Extensions.ContextPreservation;
        using Ninject.Extensions.Factory;
        public class Program
        {
            static void Main(string[] args)
            {
                new Program().Run();
            }
            public void Run()
            {
                var kernel = new StandardKernel(new NinjectSettings() { LoadExtensions = false});
                kernel.Load(new FuncModule());
                kernel.Load(new ContextPreservationModule());
                kernel.Bind<IDistributionResolver>().To<DistributionResolver>(); // This is a constructor-less object.
                kernel.Bind<ISampler>().To<SpecificSampler>();
                kernel.Bind<ISamplerFactory>().ToFactory();
                var factory = kernel.Get<ISamplerFactory>();
                this.CreateInstance(factory);
                GC.Collect();
                if (this.action1WeakReference.IsAlive || this.action2WeakReference.IsAlive || this.action3WeakReference.IsAlive) throw new Exception();
            }
            private WeakReference action1WeakReference;
            private WeakReference action2WeakReference;
            private WeakReference action3WeakReference;
            private void CreateInstance(ISamplerFactory factory)
            {
                var action1 = new Action<EventHandler<ValueChangedEventArgs>>(this.Do);
                var action2 = new Action<EventHandler<ValueChangedEventArgs>>(this.Do);
                var action3 = new Func<decimal?>(this.Query);
                this.action1WeakReference = new WeakReference(action1);
                this.action2WeakReference = new WeakReference(action2);
                this.action3WeakReference = new WeakReference(action3);
                var x = factory.Create(action1, action2, action3);
                if (x == null || !this.action1WeakReference.IsAlive || !this.action2WeakReference.IsAlive || !this.action3WeakReference.IsAlive) throw new Exception();
            }
            private void Do(EventHandler<ValueChangedEventArgs> obj)
            {
            }
            private decimal? Query()
            {
                return 0;
            }
            public class SpecificSampler : ISampler
            {
                private readonly IDistributionResolver resolver;
                private readonly Action<EventHandler<ValueChangedEventArgs>> register;
                private readonly Action<EventHandler<ValueChangedEventArgs>> unregister;
                public SpecificSampler(
                    IDistributionResolver resolver, // This is injected
                    Action<EventHandler<ValueChangedEventArgs>> register, // The rest come from the factory inputs
                    Action<EventHandler<ValueChangedEventArgs>> unregister,
                    Func<decimal?> valueGetter)
                {
                    this.resolver = resolver;
                    this.register = register;
                    this.unregister = unregister;
                    // Do Stuff;
                }
            }
            public class ValueChangedEventArgs : EventArgs
            {
            }
            public interface ISamplerFactory
            {
                ISampler Create(Action<EventHandler<ValueChangedEventArgs>> register, Action<EventHandler<ValueChangedEventArgs>> unregister, Func<decimal?> valueGetter);
            }
            public interface IDistributionResolver
            {
            }
            private class DistributionResolver : IDistributionResolver
            {
            }
            public interface ISampler
            {
            }
        }
    }
