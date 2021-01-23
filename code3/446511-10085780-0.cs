    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    using System.Threading;
    
    namespace AxControls
    {
    
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        [Guid("61327C9D-EFC5-42B7-BA0D-4A8648797003")]
        public interface IHelloWorld
        {
            string GetText();
        }
    
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("61327C9D-EFC5-42B7-BA0D-4A8648797003")]
        public interface IMyEvt
        {
            [DispId(1)]
            void OnMyEvt(int prm);
        }
    
        [ComImport()]
        [Guid("13AD0E8B-BA3F-4CDE-A7D4-8A311EC1766B")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface IObjectSafety
        {
            [PreserveSig()]
            int GetInterfaceSafetyOptions(ref Guid riid, out int pdwSupportedOptions, out int pdwEnabledOptions);
    
            [PreserveSig()]
            int SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions);
        }
    
    
        
    
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("32E6AD29-DD5F-46EA-A4D1-BD2F1E3EE064")]
        [ProgId("AxControls.HelloWorld")]
        [ComSourceInterfaces(typeof(IMyEvt))]
        public class HelloWorld : UserControl, IHelloWorld, IObjectSafety
        {
            [ComVisible(false)]
            public delegate void OnMyEvtDelgate(int prm);
    
            [DispId(1)]
            public event OnMyEvtDelgate OnMyEvt;
    
            public HelloWorld()
            {
                this.OnMyEvt += new OnMyEvtDelgate(Dummy);
            }
    
            void Dummy(int param) { }
    
            #region IHelloWorld Members
    
            public string GetText()
            {
                if (this.OnMyEvt != null) OnMyEvt(10);
                return "Hello ActiveX World!";
            }
    
            #endregion
    
            #region IObjectSafety Members
    
            public enum ObjectSafetyOptions
            {
                INTERFACESAFE_FOR_UNTRUSTED_CALLER = 0x00000001,
                INTERFACESAFE_FOR_UNTRUSTED_DATA = 0x00000002,
                INTERFACE_USES_DISPEX = 0x00000004,
                INTERFACE_USES_SECURITY_MANAGER = 0x00000008
            };
    
            public int GetInterfaceSafetyOptions(ref Guid riid, out int pdwSupportedOptions, out int pdwEnabledOptions)
            {
                ObjectSafetyOptions m_options = ObjectSafetyOptions.INTERFACESAFE_FOR_UNTRUSTED_CALLER | ObjectSafetyOptions.INTERFACESAFE_FOR_UNTRUSTED_DATA;
                pdwSupportedOptions = (int)m_options;
                pdwEnabledOptions = (int)m_options;
                return 0;
            }
    
            public int SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions)
            {
                return 0;
            }
    
            #endregion
    
        }
    
    }
