List<string> lstGenre = new List<string>();
var response = await client.PostAsync(url, content);
var responseString = await response.Content.ReadAsStringAsync();
XDocument xdoc = XDocument.Parse(responseString);
XNamespace ns = xdoc.Root.GetDefaultNamespace();
XElement root = xdoc.Element(XName.Get("ArrayOfString", ns.NamespaceName));
IEnumerable<XElement> list = root.Elements();
foreach (XElement element in list)
{
    string item = element.Value;  // <-- individual strings from the "ArrayOfString"
    lstGenre.Add(item);
}
