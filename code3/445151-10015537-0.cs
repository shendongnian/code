    var query = from tst in xml.Elements("test")
                select new 
                {
                    int1 = Int32.Parse(tst.Element("int1").Value), 
                    double1 = Double.Parse(tst.Element("double1").Value), 
                    double2 = Double.Parse(tst.Element("double2").Value), 
                }
