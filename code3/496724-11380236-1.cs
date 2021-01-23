        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("test.xml");
            var dict = new Dictionary<string, int>();
            dict["A"] = 1;
            dict["B"] = 0;
            dict["C"] = 17;
            var result = Evaluate(doc.FirstChild,dict);
        }
        static bool Evaluate(XmlNode node, IDictionary<string, int> dict)
        {
            switch (node.Name)
            {
                case "Evaluate":
                    return Evaluate(node.FirstChild.NextSibling, dict); // Ignore first comment
                case "Condition":
                    return Condition(node, dict);
                case "AND":
                    return And(node, dict);
                case "OR":
                    return Or(node, dict);
                default:
                    throw new NotSupportedException();
            }
        }
        private static bool Or(XmlNode root, IDictionary<string, int> dict)
        {
            var result = false; // Starting with false, because It will be true when at least condition is true
            foreach (XmlNode node in root.ChildNodes)
            {
                result |= Evaluate(node, dict);
            }
            return result;
        }
        private static bool And(XmlNode root, IDictionary<string, int> dict)
        {
            var result = true;
            foreach (XmlNode node in root.ChildNodes)
            {
                result &= Evaluate(node, dict);
            }
            return result;
        }
        private static bool Condition(XmlNode node, IDictionary<string, int> dict)
        {
            var name = node.Attributes["Name"].Value;
            var value = node.Attributes["Value"].Value;
            var opt = node.Attributes["Operator"].Value;
            switch (opt)
            {
                case "==":
                    return dict[name] == int.Parse(value);
                case "!=":
                    return dict[name] != int.Parse(value);
                default:
                    return false;
            }
        }
