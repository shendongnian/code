    using System;
    using Microsoft.Practices.Unity;
    public class ServiceLocator {
      private IUnityContainer m_Container = new UnityContainer();
      public void Add<TFrom, TTo>() where TTo : TFrom {
        m_Container.RegisterType<TFrom, TTo>();
      }
      public void BuildUp<T>(T instance) {
        m_Container.BuildUp<T>(instance);
      }
      public void BuildUp(Type type, object instance) {
        m_Container.BuildUp(type, instance);
      }
      public void AddSingleton<TFrom, TTo>() where TTo : TFrom {
        m_Container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
      }
      public void AddInstance<T>(T instance) {
        m_Container.RegisterInstance<T>(instance);
      }
      public T Resolve<T>() {
        return m_Container.Resolve<T>();
      }
      private static ServiceLocator m_Instance;
      public static ServiceLocator Instance {
        get { return m_Instance; }
      }
      static ServiceLocator() {
        m_Instance = new ServiceLocator();
      }
    }
    
