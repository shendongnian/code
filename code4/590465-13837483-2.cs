    public static class Extensions
    {
        public static XElement SetNamespaceRecursivly(this XElement root,
                                                      XNamespace ns)
        {
            foreach (XElement e in root.DescendantsAndSelf())
            {
                if (e.Name.Namespace == "")
                    e.Name = ns + e.Name.LocalName;
            }
            return root;    
        }
    }
    XNamespace ns = "urn:iso:std:iso:20022:tech:xsd:pacs.003.001.01";
	
    // Add DrctDbtTxInf element to pacs.003.001.01 element
    bulk.Element("{urn:S2SDDIdf:xsd:$MPEDDIdfBlkDirDeb}pacs.003.001.01")
        .Add(tx.SetNamespaceRecursivly(ns));
