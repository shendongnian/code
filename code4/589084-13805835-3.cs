     private MultiBinding createFieldMultiBinding(string fieldName) {
          // Create the multi-binding
          MultiBinding mbBinding = new MultiBinding();
          // Create the dictionary binding
          Binding bDictionary = new Binding(fieldName + "List");
          bDictionary.Source = this.DataContext;
          // Create the key binding
          Binding bKey = new Binding(fieldName);
          bKey.Source = this.DataContext;
          // Set the multi-binding converter
          mbBinding.Converter = new DictionaryItemConverter();
          // Add the bindings to the multi-binding
          mbBinding.Bindings.Add(bDictionary);
          mbBinding.Bindings.Add(bKey);
          return mbBinding;
     }
