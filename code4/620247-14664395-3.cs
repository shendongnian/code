    private void FindWMI(string servername, string classSelection, ConnectionOptions rcOptions, ListView listView)
            {
                try
                {
                    var dct = new Dictionary<string, string>();
                    List<ListViewItem> itemsList = new List<ListViewItem>();
                    oQuery = new ObjectQuery("select * from " + classSelection);
                    moSearcher = new ManagementObjectSearcher(mScope, oQuery);
                    moCollection = moSearcher.Get();
                Invoke(new MethodInvoker(() =>
                {
                    listView.Items.Clear();
                }));
                foreach (ManagementObject mObject in moCollection)
                {
                    if (mObject != null)
                    {
                        foreach (PropertyData propData in mObject.Properties)
                        {
                            if (propData.Value != null && propData.Value.ToString() != "" && propData.Name != null && propData.Name != "")
                                dct[propData.Name] = propData.Value.ToString();
    //Don't forget this, when the result is an array, you want all the strings in that array..
    if (propData.Value is Array) { dct[propData.Name] = ""; foreach (string stringArray in (string[])propData.Value) { dct[propData.Name] += stringArray + "\n"; } }
                        }
                    }
                }
                foreach (KeyValuePair<string, string> listItem in dct)
                {
                    ListViewItem lstItem = new ListViewItem(listItem.Key);
                    lstItem.SubItems.Add(listItem.Value);
                    itemsList.Add(lstItem);
                }
                Invoke(new MethodInvoker(() =>
                {
                    listView.Items.AddRange(itemsList.ToArray());
                }));
            }
            catch (Exception) { }
        }
