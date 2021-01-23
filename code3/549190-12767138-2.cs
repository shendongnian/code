    // To set the first combo box:
    cbProduct.Items.AddRange( // Add everything we produce from this to the cbProduct list
        doc.Descendants("items") // For each thing that represents an "items" tag and it's subtags
        .Select(x=>x.Element("productname").Value) // Transform it by getting the "productname" element and reading it's Value.
        .ToArray<string>()); // Then convert that into a string[].
    // To set the second combo box:
    string product2Search=cbProduct.SelectedItem.ToString();// get the currently selected value of cbProduct.
    cbBrandName.Items.Clear(); //clears all items in cbBrandNamedoc
    cbBrandName.Items.AddRange( // Add everything we produce from this to the cbBrandName list
      doc.Descendants("items") // For each thing that represents an "items" tag and it's subtags
      .Where(x=>x.Element("productname").Value==product2Search) // Filter our list to only those things where the productname matches what's currently selected in cbProduct (which we just stored)
      .Select(y=>y.Element("brandname").Value) // Transform it by getting the "brandname" element and reading it's Value.
      .ToArray<string>()); // Then convert that into a string[]
