    public class FolderBrowser
    {
        public string SelectedPath { get; set; }
        public string SelectedDesktopAbsoluteParsing { get; set; }
        public string Title { get; set; }
        public string SelectedNormalDisplay { get; private set; }
        public string SelectedUrl { get; private set; }
        public DialogResult ShowDialog(IWin32Window owner)
        {
            IShellItem result = null;
            IFileOpenDialog dialog = (IFileOpenDialog)new FileOpenDialog();
            if (!string.IsNullOrEmpty(SelectedPath))
            {
                SelectInitialPath(dialog, SelectedPath);
            }
            else if (!string.IsNullOrEmpty(SelectedDesktopAbsoluteParsing))
            {
                SelectInitialPath(dialog, SelectedDesktopAbsoluteParsing);
            }
            if (!string.IsNullOrWhiteSpace(Title))
            {
                dialog.SetTitle(Title);
            }
            dialog.SetOptions(FOS.FOS_PICKFOLDERS | FOS.FOS_ALLNONSTORAGEITEMS);
            uint hr = dialog.Show(owner != null ? owner.Handle : IntPtr.Zero);
            if (hr == ERROR_CANCELLED)
                return DialogResult.Cancel;
            if (hr != 0)
                return DialogResult.Abort;
            dialog.GetResult(out result);
            string path;
            result.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out path);
            SelectedPath = path;
            result.GetDisplayName(SIGDN.SIGDN_NORMALDISPLAY, out path);
            SelectedNormalDisplay = path;
            result.GetDisplayName(SIGDN.SIGDN_DESKTOPABSOLUTEPARSING, out path);
            SelectedDesktopAbsoluteParsing = path;
            result.GetDisplayName(SIGDN.SIGDN_URL, out path);
            SelectedUrl = path;
            return DialogResult.OK;
        }
        private void SelectInitialPath(IFileOpenDialog dialog, string path)
        {
            uint atts = 0;
            IntPtr idl = IntPtr.Zero;
            if (SHILCreateFromPath(path, out idl, ref atts) == 0)
            {
                IShellItem initial = null;
                if (SHCreateShellItem(IntPtr.Zero, IntPtr.Zero, idl, out initial) == 0)
                {
                    dialog.SetFolder(initial);
                }
                Marshal.FreeCoTaskMem(idl);
            }
        }
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHILCreateFromPath(string pszPath, out IntPtr ppIdl, ref uint rgflnOut);
        [DllImport("shell32.dll")]
        private static extern int SHCreateShellItem(IntPtr pidlParent, IntPtr psfParent, IntPtr pidl, out IShellItem ppsi);
        private const uint ERROR_CANCELLED = 0x800704C7;
        [ComImport]
        [Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7")]
        private class FileOpenDialog
        {
        }
        [Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IFileOpenDialog
        {
            [PreserveSig]
            uint Show(IntPtr parent); // IModalWindow
            void SetFileTypes();  // not fully defined
            void SetFileTypeIndex(uint iFileType);
            void GetFileTypeIndex(out uint piFileType);
            void Advise(); // not fully defined
            void Unadvise();
            void SetOptions(FOS fos);
            void GetOptions(out FOS pfos);
            void SetDefaultFolder(IShellItem psi);
            void SetFolder(IShellItem psi);
            void GetFolder(out IShellItem ppsi);
            void GetCurrentSelection(out IShellItem ppsi);
            void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);
            void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);
            void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);
            void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);
            void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);
            void GetResult(out IShellItem ppsi);
            void AddPlace(IShellItem psi, int alignment);
            void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);
            void Close(int hr);
            void SetClientGuid();  // not fully defined
            void ClearClientData();
            void SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);
            void GetResults([MarshalAs(UnmanagedType.Interface)] out IntPtr ppenum); // not fully defined
            void GetSelectedItems([MarshalAs(UnmanagedType.Interface)] out IntPtr ppsai); // not fully defined
        }
        [Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellItem
        {
            void BindToHandler(); // not fully defined
            void GetParent(); // not fully defined
            [PreserveSig]
            int GetDisplayName(SIGDN sigdnName, [MarshalAs(UnmanagedType.LPWStr)] out string ppszName);
            void GetAttributes();  // not fully defined
            void Compare();  // not fully defined
        }
        // https://msdn.microsoft.com/en-us/library/windows/desktop/bb762544.aspx
        private enum SIGDN : uint
        {
            SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,
            SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,
            SIGDN_FILESYSPATH = 0x80058000,
            SIGDN_NORMALDISPLAY = 0,
            SIGDN_PARENTRELATIVE = 0x80080001,
            SIGDN_PARENTRELATIVEEDITING = 0x80031001,
            SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,
            SIGDN_PARENTRELATIVEPARSING = 0x80018001,
            SIGDN_URL = 0x80068000
        }
        // https://msdn.microsoft.com/en-us/library/windows/desktop/dn457282.aspx
        [Flags]
        private enum FOS
        {
            FOS_ALLNONSTORAGEITEMS = 0x80,
            FOS_ALLOWMULTISELECT = 0x200,
            FOS_CREATEPROMPT = 0x2000,
            FOS_DEFAULTNOMINIMODE = 0x20000000,
            FOS_DONTADDTORECENT = 0x2000000,
            FOS_FILEMUSTEXIST = 0x1000,
            FOS_FORCEFILESYSTEM = 0x40,
            FOS_FORCESHOWHIDDEN = 0x10000000,
            FOS_HIDEMRUPLACES = 0x20000,
            FOS_HIDEPINNEDPLACES = 0x40000,
            FOS_NOCHANGEDIR = 8,
            FOS_NODEREFERENCELINKS = 0x100000,
            FOS_NOREADONLYRETURN = 0x8000,
            FOS_NOTESTFILECREATE = 0x10000,
            FOS_NOVALIDATE = 0x100,
            FOS_OVERWRITEPROMPT = 2,
            FOS_PATHMUSTEXIST = 0x800,
            FOS_PICKFOLDERS = 0x20,
            FOS_SHAREAWARE = 0x4000,
            FOS_STRICTFILETYPES = 4
        }
    }
