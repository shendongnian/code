    [
    ComImport(),
    Guid("565D8202-6C0F-4AAB-B0F6-49719CD13045"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)
    ]
    public interface ITestObject {
      [PreserveSig ]
      void DoSomething();
    }
            
    private void button1_Click(object sender, EventArgs e) {
      Type type = Type.GetTypeFromCLSID(new Guid("21293767-A713-49E2-968E-7DDE0B0DAB94"));
      object o = Activator.CreateInstance(type);
      ITestObject t = (ITestObject)o;
      t.DoSomething();
    }
