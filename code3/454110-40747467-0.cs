            string output;
            using (Stream s = ResourceUtility.GetEmbeddedResourceStream(assembly, resourceName))
            {
                StreamReader sr = new StreamReader(s);
                output = sr.ReadToEnd();
            }
            
            return CreateLocalTempFile(output, fileName);
        }
              
