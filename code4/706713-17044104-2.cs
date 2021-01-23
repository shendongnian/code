    public static void Cleanup() {
      SimpleIoc.Default.Unregister<LoginViewModel>(CurrentKey);
      ...
      CurrentKey = System.Guid.NewGuid().ToString();
    }
