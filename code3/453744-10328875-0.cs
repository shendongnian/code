    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows;
    using System.Windows.Interop;
    namespace LoginDialog
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                // Declare/initialize variables.
                bool save = false;
                int errorcode = 0;
                uint dialogReturn;
                uint authPackage = 0;
                IntPtr outCredBuffer;
                uint outCredSize;
                // Create the CREDUI_INFO struct.
                CREDUI_INFO credui = new CREDUI_INFO();
                credui.cbSize = Marshal.SizeOf(credui);
                credui.pszCaptionText = "Connect to your application";
                credui.pszMessageText = "Enter your credentials!";
                credui.hwndParent = new WindowInteropHelper(this).Handle;
                // Show the dialog.
                dialogReturn = CredUIPromptForWindowsCredentials(
                    ref credui, 
                    errorcode, 
                    ref authPackage,
                    (IntPtr)0,  // You can force that a specific username is shown in the dialog. Create it with 'CredPackAuthenticationBuffer()'. Then, the buffer goes here...
                    0,          // ...and the size goes here. You also have to add CREDUIWIN_IN_CRED_ONLY to the flags (last argument).
                    out outCredBuffer, 
                    out outCredSize, 
                    ref save, 
                    0); // Use the PromptForWindowsCredentialsFlags Enum here. You can use multiple flags if you seperate them with | .
                if (dialogReturn == 1223) // Result of 1223 means the user canceled. Not sure if other errors are ever returned.
                    textBox1.Text += ("User cancelled!");
                if (dialogReturn != 0) // Result of something other than 0 means...something, I'm sure. Either way, failed or canceled.
                    return;
                var domain = new StringBuilder(100);
                var username = new StringBuilder(100);
                var password = new StringBuilder(100);
                int maxLength = 100; // Note that you can have different max lengths for each variable if you want.
                // Unpack the info from the buffer.
                CredUnPackAuthenticationBuffer(0, outCredBuffer, outCredSize, username, ref maxLength, domain, ref maxLength, password, ref maxLength);
                // Clear the memory allocated by CredUIPromptForWindowsCredentials.
                CoTaskMemFree(outCredBuffer);
                // Output info, escaping whitespace characters for the password.
                textBox1.Text += String.Format("Domain: {0}\n", domain);
                textBox1.Text += String.Format("Username: {0}\n", username);
                textBox1.Text += String.Format("Password (hashed): {0}\n", EscapeString(password.ToString()));
            }
            public static string EscapeString(string s)
            {
                // Formatted like this only for you, SO.
                return s
                    .Replace("\a", "\\a")
                    .Replace("\b", "\\b")
                    .Replace("\f", "\\f")
                    .Replace("\n", "\\n")
                    .Replace("\r", "\\r")
                    .Replace("\t", "\\t")
                    .Replace("\v", "\\v");
            }
            #region DLLImports
            [DllImport("ole32.dll")]
            public static extern void CoTaskMemFree(IntPtr ptr);
            [DllImport("credui.dll", CharSet = CharSet.Unicode)]
            private static extern uint CredUIPromptForWindowsCredentials(ref CREDUI_INFO notUsedHere, int authError, ref uint authPackage, IntPtr InAuthBuffer,
              uint InAuthBufferSize, out IntPtr refOutAuthBuffer, out uint refOutAuthBufferSize, ref bool fSave, PromptForWindowsCredentialsFlags flags);
            [DllImport("credui.dll", CharSet = CharSet.Unicode)]
            private static extern bool CredUnPackAuthenticationBuffer(int dwFlags, IntPtr pAuthBuffer, uint cbAuthBuffer, StringBuilder pszUserName, ref int pcchMaxUserName, StringBuilder pszDomainName, ref int pcchMaxDomainame, StringBuilder pszPassword, ref int pcchMaxPassword);
            #endregion
            #region Structs and Enums
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            private struct CREDUI_INFO
            {
                public int cbSize;
                public IntPtr hwndParent;
                public string pszMessageText;
                public string pszCaptionText;
                public IntPtr hbmBanner;
            }
            private enum PromptForWindowsCredentialsFlags
            {
                /// <summary>
                /// The caller is requesting that the credential provider return the user name and password in plain text.
                /// This value cannot be combined with SECURE_PROMPT.
                /// </summary>
                CREDUIWIN_GENERIC = 0x1,
                /// <summary>
                /// The Save check box is displayed in the dialog box.
                /// </summary>
                CREDUIWIN_CHECKBOX = 0x2,
                /// <summary>
                /// Only credential providers that support the authentication package specified by the authPackage parameter should be enumerated.
                /// This value cannot be combined with CREDUIWIN_IN_CRED_ONLY.
                /// </summary>
                CREDUIWIN_AUTHPACKAGE_ONLY = 0x10,
                /// <summary>
                /// Only the credentials specified by the InAuthBuffer parameter for the authentication package specified by the authPackage parameter should be enumerated.
                /// If this flag is set, and the InAuthBuffer parameter is NULL, the function fails.
                /// This value cannot be combined with CREDUIWIN_AUTHPACKAGE_ONLY.
                /// </summary>
                CREDUIWIN_IN_CRED_ONLY = 0x20,
                /// <summary>
                /// Credential providers should enumerate only administrators. This value is intended for User Account Control (UAC) purposes only. We recommend that external callers not set this flag.
                /// </summary>
                CREDUIWIN_ENUMERATE_ADMINS = 0x100,
                /// <summary>
                /// Only the incoming credentials for the authentication package specified by the authPackage parameter should be enumerated.
                /// </summary>
                CREDUIWIN_ENUMERATE_CURRENT_USER = 0x200,
                /// <summary>
                /// The credential dialog box should be displayed on the secure desktop. This value cannot be combined with CREDUIWIN_GENERIC.
                /// Windows Vista: This value is not supported until Windows Vista with SP1.
                /// </summary>
                CREDUIWIN_SECURE_PROMPT = 0x1000,
                /// <summary>
                /// The credential provider should align the credential BLOB pointed to by the refOutAuthBuffer parameter to a 32-bit boundary, even if the provider is running on a 64-bit system.
                /// </summary>
                CREDUIWIN_PACK_32_WOW = 0x10000000,
            }
            #endregion
        }
    }
