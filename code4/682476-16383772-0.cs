    // !! http://sandsprite.com/blogs/index.php?uid=11&pid=83
    
    using System;
    using MSScriptControl;
    
    //class test has to support IDispatch to AddObject(). So make the assembly ComVisible
    //via AssemblyInfo.cs or [assembly: System.Runtime.InteropServices.ComVisible(true)]
    
    namespace MsScTest {
        public class CsHelper {
            public int increment(int y) { return ++y; }
        }
    
        class Program {
            public static MSScriptControl.ScriptControl sc = new ScriptControl();
            static void Main(string[] args) {
                sc.Language = "VBScript";
                sc.AddObject("CsHelper", new CsHelper(), true);
                sc.AddCode(@"
    Function inc(n)
      inc = CsHelper.increment(n)
    End Function
    MsgBox inc(4711), 0, 'With a little help from my friend CsHelper'
    ".Replace("'", "\""));
                return;
            }
        }
    }
