    [System.Runtime.InteropServices.ComVisible(true)]
    public class CSharpClass
    {
        public void MsgBox(string s)
        {
            MessageBox.Show(s);
        }
    }
-
    Type scriptType = Type.GetTypeFromCLSID(Guid.Parse("0E59F1D5-1FBE-11D0-8FF2-00A0D10038BC"));
    dynamic obj = Activator.CreateInstance(scriptType, false);
    obj.Language = "Javascript";
    obj.AddObject("mywindow", new CSharpClass(), true);
    var result = obj.Eval(
        @"
            function test(){
                mywindow.MsgBox('hello'); 
            }
            test();
        "
        );
