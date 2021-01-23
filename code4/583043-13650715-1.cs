    public class Presenter : BasePresenter <ViewModel, View>
    {
        Client client;
        IView view;
        ViewModel viewModel;
        
        public Presenter(int clientId, IView viewParam, ViewModel viewModelParam)
        {
            this.view = viewParam;
            this.viewModel = viewModelParam;
            client = viewModel.FindById(clientId);
            BindData(client);
            wireEventsTo(view); //Implement on the base class
        }
        public void OnSaveClient(object sender, EventArgs e)
        {
            viewModel.Save(client);
        }
        public void OnEnter(object sender, EventArgs e)
        {
            MessageBox.Show("It works!");
        }
        public void OnMyLittleListChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
