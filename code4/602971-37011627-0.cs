        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections;
    
    namespace Bridge
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                dynamic app = Activator.CreateInstance(Type.GetTypeFromProgID("Photoshop.Application"));
    
                //Get list of select files from Bridge
                String Code = "var fileList;" +
                "var bt = new BridgeTalk();" +
                "bt.target = 'bridge';" +
                "bt.body = 'var theFiles = photoshop.getBridgeFileListForAutomateCommand();theFiles.toSource();';" +
                "bt.onResult = function( inBT ) { fileList = eval( inBT.body ); }" +
                "bt.onError = function( inBT ) { fileList = new Array(); }" +
                "bt.send(8);" +
                "if ( undefined == fileList ) {" +
                "fileList = new Array();}" +
                "fileList = decodeURI(fileList.toString());";
    
                String RC = app.DoJavaScript(Code, null, null);
                ArrayList list = new ArrayList();
                list.AddRange(RC.Split(new char[] { ',' }));
                for (int index = 0; index < list.Count; index++)
                {
                    Console.WriteLine(list[index]);
                }
                Console.ReadLine();
    
            }
        }
    }
