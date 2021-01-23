    public class MyPublicData
    {
      public int id;
      public string value;
    }
    [Serializable()]
    class MyEncapsulatedData
    {
      private DateTime created;
      private int length;
      public MyEncapsulatedData(int length)
      {
         created = DateTime.Now;
         this.length = length;
      }
      public DateTime ExpirationDate
      {
         get { return created.AddDays(length); }
      }
    }
    class Program
    {
      static void Main(string[] args)
      {
         string testpath = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestFile");
         // Method 1: Automatic XML serialization
         // Requires that the type being serialized and all its serializable members are public
         System.Xml.Serialization.XmlSerializer xs = 
            new System.Xml.Serialization.XmlSerializer(typeof(MyPublicData));
         MyPublicData o1 = new MyPublicData() {id = 3141, value = "a test object"};
         MyEncapsulatedData o2 = new MyEncapsulatedData(7);
         using (System.IO.StreamWriter w = new System.IO.StreamWriter(testpath + ".xml"))
         {
            xs.Serialize(w, o1);
         }
         // Method 2: Manual XML serialization
         System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(testpath + "1.xml");
         xw.WriteStartElement("MyPublicData");
         xw.WriteStartAttribute("id");
         xw.WriteValue(o1.id);
         xw.WriteEndAttribute();
         xw.WriteAttributeString("value", o1.value);
         xw.WriteEndElement();
         xw.Close();
         // Method 3: Automatic binary serialization
         // Requires that the type being serialized be marked with the "Serializable" attribute
         using (System.IO.FileStream f = new System.IO.FileStream(testpath + ".bin", System.IO.FileMode.Create))
         {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = 
               new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bf.Serialize(f, o2);
         }
         // Demonstrate how automatic binary deserialization works
         // and prove that it handles objects with private members
         using (System.IO.FileStream f = new System.IO.FileStream(testpath + ".bin", System.IO.FileMode.Open))
         {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
               new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            MyEncapsulatedData o3 = (MyEncapsulatedData)bf.Deserialize(f);
            Console.WriteLine(o3.ExpirationDate.ToString());
         }
         // Method 4: Manual binary serialization
         using (System.IO.FileStream f = new System.IO.FileStream(testpath + "1.bin", System.IO.FileMode.Create))
         {
            using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(f))
            {
               w.Write(o1.id);
               w.Write(o1.value);
            }
         }
         // Demonstrate how manual binary deserialization works
         using (System.IO.FileStream f = new System.IO.FileStream(testpath + "1.bin", System.IO.FileMode.Open))
         {
            using (System.IO.BinaryReader r = new System.IO.BinaryReader(f))
            {
               MyPublicData o4 = new MyPublicData() { id = r.ReadInt32(), value = r.ReadString() };
               Console.WriteLine("{0}: {1}", o4.id, o4.value);
            }
         }
      }
    }
