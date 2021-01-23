    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    ...
    var query = from date in xmlDoc.Root.Elements("Serial");
    ...
