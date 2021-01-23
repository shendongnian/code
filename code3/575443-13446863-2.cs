    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace CSharpCom
    {
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        //The 3 GUIDs in this file need to be unique for your COM object.
        //Generate new ones using Tools->Create GUID in VS2010
        [Guid("18C66A75-5CA4-4555-991D-7115DB857F7A")] 
        public interface ICSharpCom
        {
            string Format(string FormatString, [Optional]object arg0, [Optional]object arg1, [Optional]object arg2, [Optional]object arg3);
            void ShowMessageBox(string SomeText);
        }
    
        //TODO: Change me!
        [Guid("5D338F6F-A028-41CA-9054-18752D14B1BB")] //Change this 
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        interface ICSharpComEvents
        {
    		//Add event definitions here. Add [Disp(1..n)] attributes
    		//before each event declaration.
        }
    
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        [ComSourceInterfaces(typeof(ICSharpComEvents))]
        //TODO: Change me!
        [Guid("C17C5EAD-AA14-464E-AD32-E9521AC17134")]
        public sealed class CSharpCom : ICSharpCom
        {
    		public string Format(string FormatString, [Optional]object arg0, [Optional]object arg1, [Optional]object arg2, [Optional]object arg3)
    		{
                return string.Format(FormatString, arg0, arg1, arg2, arg3);   
    		}
    
            public void ShowMessageBox(string SomeText)
            {
                MessageBox.Show(SomeText);
            }
    	}
    }
