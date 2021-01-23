    public class View {
        ...
        myViewModel.OnFail = () => {this.Close();};
        ...
    }
    public class MyViewModel {
        public Action OnFail {get; set;}
        private void Login() {
            ....
            if (failed && OnFail != null)
                OnFail();
        }
    }
