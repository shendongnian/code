    namespace SO_10281928
    {
        class Program
        {
            static void Main(string[] args)
            {
                var instance = new Stamp
                                   {
                                       Name = "Test",
                                       SmallIcon = "Small Icon",
                                       LargeIcon = "LargeIcon",
                                       MediumIcon = "MediumIcon"
                                   };
    
                using (var stream = new FileStream(@"c:\temp\stamp.xml", FileMode.Create))
                {
                    var ds = new DataContractSerializer(typeof (Stamp));
                    ds.WriteObject(stream, instance);
                }
    
                Console.WriteLine("Done.");
                Console.ReadLine();
            }
        }
    
        [DataContract]
        public class Stamp
        {
            private string _Name;
            private string _SmallIcon = "";
            private string _MediumIcon = "";
            private string _LargeIcon = "";
    
            private BitmapImage _SmallImage;
            private BitmapImage _MediumImage;
            private BitmapImage _LargeImage;
    
            [DataMember]
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }
    
            [DataMember]
            public string SmallIcon
            {
                get { return _SmallIcon; }
                set { _SmallIcon = value; }
            }
    
            [DataMember]
            public string MediumIcon
            {
                get { return _MediumIcon; }
                set { _MediumIcon = value; }
            }
    
            [DataMember]
            public string LargeIcon
            {
                get { return _LargeIcon; }
                set { _LargeIcon = value; }
            }
    
            public BitmapImage SmallImage
            {
                get { return _SmallImage; }
                set { _SmallImage = value; }
            }
    
            public BitmapImage MediumImage
            {
                get { return _MediumImage; }
                set { _MediumImage = value; }
            }
    
            public BitmapImage LargeImage
            {
                get { return _LargeImage; }
                set { _LargeImage = value; }
            }
        }
    
        public class BitmapImage
        {
        }
    }
