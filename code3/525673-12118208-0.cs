    Type scriptType = Type.GetTypeFromCLSID(Guid.Parse("0E59F1D5-1FBE-11D0-8FF2-00A0D10038BC"));
    dynamic obj = Activator.CreateInstance(scriptType, false);
    obj.Language = "javascript";
    obj.AddObject("MyClass",new JSAccessibleClass());
    obj.Eval("MyClass.MsgBox('Hello World')"); //<--1
    var result = obj.Eval("3+5"); //<--2
    [ComVisible(true)]
    public class JSAccessibleClass
    {
        public void MsgBox(string s)
        {
            MessageBox.Show(s);
        }
    }
    
