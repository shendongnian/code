    //think better use IEnumerable<object>, because you don't really need JSON array
        foreach (var item in (IEnumerable<object>)result["data"])
                          {
                             var name = (item as IDictionary<string, object>)["name"];
                             //message box for testing purposes
                             MessageBox.Show(name);
                          }
