        static void Main(string[] args)
        {
            saveData obj = new saveData();
           
            FileStream fopen = new FileStream("abc.xml", FileMode.Open);
            XmlSerializer x = new XmlSerializer(obj.GetType());
            StreamReader read_from_xml = new StreamReader(fopen);
            obj = (saveData)x.Deserialize(read_from_xml);
            
                Console.WriteLine(obj.strFolder1 + "=>" + obj.strFolder2 + "=>" + obj.strTabName+"=>"+obj.strTabText);
            Console.ReadKey();
            fopen.Close();
        }
    }
    
}
