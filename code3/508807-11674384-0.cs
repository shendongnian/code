     public abstract class BaseViewModelDL {
        protected IEnumerable<Project> LoadProjects() {
            BaseServiceClient client = new BaseServiceClient();
            return client.Projects();
        }
    public class SynchronousViewModelDL : BaseViewModelDL, IIMViewModelDL {
        public void LoadProjects(AssignProjects callback) {
            callback(base.LoadProjects());
        }
    public class AsyncIMViewModelDL : BaseViewModelDL, IIMViewModelDL {
        public void LoadProjects(AssignProjects callback) {
            BackgroundWorker loadProjectsAsync = new BackgroundWorker();
            loadProjectsAsync.DoWork += new DoWorkEventHandler(LoadProjectsAsync_DoWork);
            loadProjectsAsync.RunWorkerCompleted += new RunWorkerCompletedEventHandler(LoadProjectsAsync_RunWorkerCompleted);
            loadProjectsAsync.RunWorkerAsync(callback);
        }
    void LoadProjectsAsync_DoWork(object sender, DoWorkEventArgs e) {
            var results = new ObservableCollection<Project>(base.LoadProjects());
            e.Result = new object[] { results, e.Argument };
        }
        void LoadProjectsAsync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            AssignProjects callback = (AssignProjects)((object[])e.Result)[1];
            IEnumerable<Project> results = (IEnumerable<Project>)((object[])e.Result)[0];
            callback(results);
        }
