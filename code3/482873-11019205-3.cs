    public class ProcessModule : Autofac.Module
    {
      private IEnumerable<string> _constants;
      public ProcessModule(IEnumerable<string> constants)
      {
        this._constants = constants;
      }
      protected override void Load(ContainerBuilder builder)
      {
        // Put the foreach here and loop over this._constants.
      }
    }
