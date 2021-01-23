        foreach (ManagementObject obj in searcher.Get()) {
            foreach (var prop in obj.Properties) {
                if (prop.Value != null) {
                    txtBox.AppendText(string.Format("{0} = {1}", prop.Name, prop.Value));
                }
            }
        }
