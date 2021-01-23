    public class MySettings 
    {
      public String name {get;set;}
      public String name {get;set;}
      public DateTime date {get;set;}
      public bool checked {get;set;}
    }
    void Save() 
    {
      var s = new MySettings 
      {
        name = this.task1_Name.Text,
        desc = this.task1_Desc.Text,
        date = this.task1_Date.Value,
        checked = this.task1_Check.Checked
      };
      var ser = new XmlSerializer(typeof(MySettings));
      using (var fs = new FileStream(path, FileMode.Create))
      {
          using (var tw = new StreamWriter(fs, new UTF8Encoding()))
          {
              var ns = new XmlSerializerNamespaces();
              ns.Add("", "");
              ser.Serialize(tw, this, ns);
          }
      }
    }
 
    
