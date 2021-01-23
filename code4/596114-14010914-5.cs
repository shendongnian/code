    class Program
    {
        static IEnumerable<Person> Populate(IEnumerable<HtmlNode> children)
        {
            foreach (var child in children)
            {
                var person = new Person
                {
                    Name = child.InnerText.Split(new char[] { '\r', '\n' })[0].Trim(),
                    Children = new PeopleList()
    
                };
                person.Children.People = new List<Person>();
                foreach (var childrenOf in child.Elements("ol").SelectMany(BuildFromHtml))
                {
                    person.Children.People.Add(childrenOf);
                }
                yield return person;
            }
    
    
        }
        static IEnumerable<Person> BuildFromHtml(HtmlNode node)
        {
            return Populate(node.Elements("li"));
        }
    
        static void Main(string[] args)
        {
            const string html = @"<ol>
                <li>Heather</li>
                <li>Channing</li>
                <li>Briana</li>
                <li>Amber</li>
                <li>Sabrina</li>
                <li>Jessica
                    <ol>
                        <li>Melody</li>
                        <li>Dakota</li>
                        <li>Sierra</li>
                        <li>Vandi</li>
                        <li>Crystal</li>
                        <li>Samantha</li>
                        <li>Autumn</li>
                        <li>Ruby</li>
                    </ol></li>
                <li>Taylor</li>
                <li>Tara</li>
                <li>Tammy</li>
                <li>Laura</li>
                <li>Shelly</li>
                <li>Shantelle</li>
                <li>Bob and Alice
                  <ol>
                    <li>Courtney</li>
                    <li>Misty</li>
                    <li>Jenny</li>
                    <li>Christa</li>
                    <li>Mindy</li>
                  </ol></li>
                <li>Noel</li>
                <li>Shelby</li>
            </ol>";
    
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var listOfPeople = BuildFromHtml(doc.DocumentNode.FirstChild).ToList();
        }
    }
