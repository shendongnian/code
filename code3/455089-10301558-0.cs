    using System;
    using Autofac;
    using Autofac.Core;
    public class LangModule : Module:
    {
      private string _lang;
      public LangModule(string lang)
      {
        this._lang = lang;
      }
      protected override void AttachToComponentRegistration(
        IComponentRegistry componentRegistry,
        IComponentRegistration registration)
      {
        // Any time a component is resolved, it goes through Preparing
        registration.Preparing += InjectLangParameter;
      }
      protected void InjectLangParameter(object sender, PreparingEventArgs e)
      {
        // Add your named parameter to the list of available parameters.
        e.Parameters = e.Parameters.Union(
          new[] { new NamedParameter("lang", this._lang) });
      }
    }
