    namespace WPFTest.ViewModels
    {
    using System.IO;
    using System.Windows.Input;
    using Microsoft.Practices.Prism.Commands;
    public class MainViewModel : NotificationObject
    {
        public MainViewModel()
        {
            FileList = new Dictionary<string, string>();
            FillFileListCommand = new DelegateCommand(FillFileListExecuted);
        }
        private Dictionary<string, string> fileList;
        public Dictionary<string,string> FileList
        {
            get
            {
                return fileList;
            }
            set
            {
                fileList = value;
                RaisePropertyChanged(()=>FileList);
            }
        }
        public ICommand FillFileListCommand { get; set; }
        private void FillFileListExecuted()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var files = Directory.GetFiles(path, "*.txt");
            var dict = new Dictionary<string, string>();
            foreach (var file in files)
            {
                using (var reader = new StreamReader(file))
                {
                    var text = reader.ReadToEnd();
                    dict.Add(file, text);
                }
            }
            FileList = dict;
        }
    }
