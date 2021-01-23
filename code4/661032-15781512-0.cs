    class Program {
    static void Main(string[] args) {
    // this is a sample string. Use your file instead
    string s = "<catalog>" +
    "<book id=\"bk101\" author=\"Gambardella, Matthew\" title=\"XML Developer's Guide\" genre=\"Computer\"/>" +
    "<book id=\"bk102\" author=\"Ralls, Kim\" title=\"Midnight Rain\" genre=\"Fantasy\"/>" +
    "</catalog>";
    
    XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(s); // here we load data
    // here we get attributes. I have three, you will add three more. Also you may want to use string array instead of variables
                foreach (XmlNode task in xdoc.DocumentElement.ChildNodes)
    {
                    string author = task.Attributes["author"].InnerText;
                    string title = task.Attributes["title"].InnerText;
                    string genre = task.Attributes["genre"].InnerText;
                }
            }
        }
