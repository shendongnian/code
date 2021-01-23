    [XmlRoot(ElementName = "MntProdHierAttrMDM")]
    public class RecordCollection : List<Record>
    {
       public RecordCollection() : base(){}
       public RecordCollection(int capacity) : base(capacity){}
    }
    
    
    void MainFormLoad(object sender, EventArgs e)
    {
        if (ItemFile.Exists)
        {
            RecordCollection lst = new RecordCollection();
            XmlSerializer xml = new XmlSerializer(typeof(RecordCollection));
    
            using (Stream s = ItemFile.OpenRead())
            {
                lst = xml.Deserialize(s) as RecordCollection;
            }
    
            _items.Add(item);
    
            MessageBox.Show(lst[0].Material_Code);
        }
    }
