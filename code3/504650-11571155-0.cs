    public class result_tree
    {
        public string nodevalue = "";
        public bool IsTerminal { get { return ChildCount == 0; } }
        public List<result_tree> children = new List<result_tree>();
        public int ChildCount { get { return children.Count; } }
        public result_tree(string v) { nodevalue = v; }
        private void print_children(bool skip, string prefix)
        {
            if (IsTerminal)
                Console.WriteLine(prefix + (prefix.Length==0?"":"/") + nodevalue);
            else
                foreach (result_tree rt in children)
                    rt.print_children(false,prefix + (prefix.Length == 0 ? "" : "/") + (skip?"":nodevalue));
        }
        public void print_children()
        {
            print_children(true,"");
        }
    }
    static class Program
    {
        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            Console.WriteLine(args.Message);
        }
        public static result_tree results;
        static string deref_simple(XmlSchemaSimpleType simp)
        {
            XmlSchemaSimpleTypeRestriction xsstr = (XmlSchemaSimpleTypeRestriction)simp.Content;
            foreach (object o in xsstr.Facets)
            {
                if (o.GetType() == typeof(XmlSchemaMaxLengthFacet))
                {
                    XmlSchemaMaxLengthFacet fac = (XmlSchemaMaxLengthFacet)o;
                    return fac.Value;
                }
            }
            return "";
        }
        static result_tree deref_complex(XmlSchema xs, XmlSchemaComplexType cplx)
        {
            result_tree rt = new result_tree(cplx.Name);
            if (cplx.Particle.GetType() == typeof(XmlSchemaSequence))
            {
                XmlSchemaSequence seq = (XmlSchemaSequence)cplx.Particle;
                foreach (object o in seq.Items)
                {
                    if (o.GetType() == typeof(XmlSchemaElement))
                    {
                        XmlSchemaElement elem = (XmlSchemaElement)o;
                        XmlQualifiedName name = elem.SchemaTypeName;
                        result_tree branch;
                        object referto = xs.SchemaTypes[name];
                        if (referto.GetType() == typeof(XmlSchemaComplexType))
                        {
                            branch = deref_complex(xs,(XmlSchemaComplexType)referto);
                            branch.nodevalue = elem.Name;
                        }
                        else if (referto.GetType() == typeof(XmlSchemaSimpleType))
                        {
                            XmlSchemaSimpleType st = (XmlSchemaSimpleType)referto;
                            branch = new result_tree(elem.Name + " = " + deref_simple(st).ToString());
                        }
                        else
                        {
                            branch = null;
                        }
                        if( branch != null )
                            rt.children.Add(branch);
                    }
                }
            }
            return rt;
        }
      
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            StreamReader sr = new StreamReader("aschema.xml");
            XmlSchema xs = XmlSchema.Read(sr, ValidationCallBack);
            XmlSchemaSet xss = new XmlSchemaSet();
            xss.Add(xs);
            xss.Compile();
            Console.WriteLine("Query: ");
            string q = Console.ReadLine();
            XmlQualifiedName xqn = new XmlQualifiedName(q);
            if (xs.SchemaTypes.Contains(xqn))
            {
                object o = xs.SchemaTypes[xqn];
                if (o.GetType() == typeof(XmlSchemaComplexType))
                {
                    results = deref_complex(xs, (XmlSchemaComplexType)o);
                    results.print_children();
                }   
            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }
    }
