    public class ClipboardBackup
    {
        Dictionary<string, object> contents = new Dictionary<string,object>();
        public void Backup()
        {
            contents.Clear();
            IDataObject o = Clipboard.GetDataObject();
            foreach (string format in o.GetFormats())
                contents.Add(format, o.GetData(format));
        }
        public void Restore()
        {
            DataObject o = new DataObject();
            foreach (string format in contents.Keys)
            {
                o.SetData(format, contents[format]);
            }
            Clipboard.SetDataObject(o);
        }
    }
