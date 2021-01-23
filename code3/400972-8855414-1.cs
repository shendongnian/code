    class DataDisplayer<T>
    {
        Label myLabel = new Label();
        public void Display(IFetch<T> fetch, int id)
        {
            myLabel.Text = fetch.Fetch(id).ToString();
        }
    }
