    [Serializable]
    public class Student
    {
        public string stuID { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public void CopyToClipboard()
        {
            DataFormats.Format format =
                 DataFormats.GetFormat(typeof(Student).FullName);
            //now copy to clipboard
            IDataObject dataObj = new DataObject();
            dataObj.SetData(format.Name, false, this);
            Clipboard.SetDataObject(dataObj, false);
        }
