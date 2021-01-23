    public class UIForm
    {
        public event ErrorEventHandler ErrorOccurred;
        protected void RaiseErrorEvent(ErrorEventArgs e)
        {
            ErrorEventHandler eh = ErrorOccurred;
            if (eh != null)
            {
                eh.Invoke(this, e);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            IList<AppConfig> AppConfigs = AppConfigService.All().Where(a => (a.IsActive == true) && (a.ConfigProperty == "MaterialImages")).ToList();
            string ImageNameFilter = txtCode.Text;
            if (!ucFileExplorer.IsSavedImage(AppConfigs, ImageNameFilter))
            {
                RaiseErrorEvent(new ErrorEventArgs());
                return;
            }
            if (Save())
            {
                LoadForm<Materials>();
            }
        }
    }
