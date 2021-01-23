    using System;
    using System.IO;
    using System.Windows.Forms;
    
    namespace DirCombination 
    {
        public partial class DirCombination : Form
        {
            private const string _Path = @"D:/folder1/foler2/folfer3/folder4/file.txt";
            private string _finalPath = null;
            private string _error = null;
    
            public DirCombination()
            {
                InitializeComponent();
    
                if (!FSParse(_Path))
                    Console.WriteLine(_error);
                else
                    Console.WriteLine(_finalPath);
            }
    
            private bool FSParse(string path)
            {
                try
                {
                    string[] Splited = path.Replace(@"//", @"/").Replace(@"\\", @"/").Replace(@"\", "/").Split(':');
                    string NewPath = Splited[0] + ":";
                    if (Directory.Exists(NewPath))
                    {                    
                        string[] Paths = Splited[1].Substring(1).Split('/');
    
                        for (int i = 0; i < Paths.Length - 1; i++)
                        {
                            NewPath += "/";
                            if (!string.IsNullOrEmpty(Paths[i]))
                            {
                                NewPath += Paths[i];
                                if (!Directory.Exists(NewPath))
                                    Directory.CreateDirectory(NewPath);
                            }
                        }
    
                        if (!string.IsNullOrEmpty(Paths[Paths.Length - 1]))
                        {
                            NewPath += "/" + Paths[Paths.Length - 1];
                            if (!File.Exists(NewPath))
                                File.Create(NewPath);
                        }
                        _finalPath = NewPath;
                        return true;
                    }
                    else
                    {
                        _error = "Drive is not exists!";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    _error = ex.Message;
                    return false;
                }
            }
        }
    }
