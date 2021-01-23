    static private void ResolveExternal(
      XmlSchema rootSchema, 
      XmlSchema curSchema,
      List<string> processed
    )
    {
      // Loop on all the includes
      foreach (XmlSchemaExternal external in curSchema.Includes) {
        // Avoid processing twice the same include file
        if (!processed.Contains(external.SchemaLocation)) {
          processed.Add(external.SchemaLocation);
          XmlSchema cur = external.Schema;
          // Recursive calls to handle includes inside the include
          ResolveExternal(rootSchema, cur, processed);
          // Move the items from the included schema to the root one
          foreach (XmlSchemaObject item in cur.Items) {
            rootSchema.Items.Add(item);
          }
        }
      }
      curSchema.Includes.Clear();
    } // ResolveExternal
    static public void ResolveExternal(XmlSchema schema)
    {
      List<string> processed = new List<string>();
      ResolveExternal(schema, schema, processed);
    } // ResolveExternal
