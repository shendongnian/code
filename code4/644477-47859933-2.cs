        public static SerializedClipboardFragment getSerializedFragment()
        {
            if (!Clipboard.ContainsData(SerializedClipboardFragment.s_format.Name))
            {
                return null;
            }
            // sometimes return MemoryStream object instead under automated-testing
            // possibly a timing problem
            object o = null;
            for (int i = 0; i < 10; ++i)
            {
                o = Clipboard.GetData(SerializedClipboardFragment.s_format.Name);
                if (o is SerializedClipboardFragment)
                    return (SerializedClipboardFragment)o;
                System.Threading.Thread.Sleep(100);
            }
            return (SerializedClipboardFragment)o;
        }
