        void Dump(DicomAttributeCollection collection, string prefix, StringBuilder sb)
        {     
            foreach (DicomAttribute attribute in collection)
            {
                var attribSQ = attribute as DicomAttributeSQ;
                if (attribSQ != null)
                {                    
                    for (int i=0; i< attribSQ.Count; i++) 
                    {
                        sb.AppendLine(prefix + "SQ Item: " + attribSQ.ToString());
                        DicomSequenceItem sqItem = attribSQ[i];
                        Dump(sqItem, prefix + "\t", sb);
                    }
                }
                else
                {
                    sb.AppendLine(prefix + attribute.ToString());
                }
            }
        }
