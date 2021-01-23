     private void readProperties(Type T, int indent, object obj) {
        //...
        var value = prop.GetValue(obj, null); 
        if (prop.PropertyType.IsPrimive) {
            richTextBox1.AppendText(prop.Name + "\t\t" + value.ToString() +"\n");
        }
        else {
            richTextBox1.AppendText(prop.Name + ":\n");
            readProperties(prop.PropertyType, indent+1, value);
        }
     }
