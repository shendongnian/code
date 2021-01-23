    // Retrieve reference to the container.
    CloudBlobContainer container = BlobClient.GetContainerReference(lvContainer.SelectedItems[0].Text);
    //Loop over VIRTUAL directories within the container
    foreach (IListBlobItem item in container.ListBlobs())
    {
          if (item.GetType() == typeof(CloudBlobDirectory))
          {
               CloudBlobDirectory directory = (CloudBlobDirectory)item;
               string[] uri = directory.Uri.ToString().Split('/');
               ListViewItem dir = new ListViewItem();
               dir.Text = uri[uri.Length-2];
               dir.ImageIndex = 0;
               ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
               subitem.Text = String.Empty; //item.Properties.LastModifiedUtc.ToString();
               dir.SubItems.Add(subitem);
               subitem = new ListViewItem.ListViewSubItem();
               subitem.Text = String.Empty; //item.Properties.Length + " bytes";
               dir.SubItems.Add(subitem);
               lvBlob.Items.Add(dir);
           }
    }
