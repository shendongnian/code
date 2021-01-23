    public static GenericList Instance {
        
            get {
            
                    XElement xelement = XElement.Load(HostingEnvironment.MapPath("RelativeFilepath"));
                    IEnumerable<XElement> items = xelement.Elements();
                    instance = new GenericList();
                    instance.genericList = new List<GenericItem>{ };
                    
                    foreach (var item in items) {
                    
                        //Get the value of XML fields here
                        int _id = int.Parse(item.Element("id").Value);
                        string _name = item.Element("name").Value;
                        instance.genericList.Add(
                                      new GenericItem() {
                                      
                                          //Load data into your object
                                          id = _id,
                                          name = _name
                                      });   
                        }
                return instance;
            }
        }
