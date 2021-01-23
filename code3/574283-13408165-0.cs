    this.client.GetAsync<RepositoryResponse>(string.Format
    ("/repository?Dto={0}", reader.Dto.ToJson()),
    r => {
        myListBox.Dispatcher.Invoke(
            System.Windows.Threading.DispatcherPriority.Normal, () => {
               //populate results int myListBox
            }); 
    },
    (r, x) => ReadErrorCallback(r, x));
