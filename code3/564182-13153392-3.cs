        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.ComponentModel;
        using Unattended_Tool.View.DataStore;
        using System.Collections.ObjectModel;
        using System.Xml.Serialization;
        namespace Unattended_Tool
        {
    public class ICTSPrinter : IDataErrorInfo
    {
        string _name;
        string _versionsname;
        string _location;
        ObservableCollection<int> _categorie;
        public ObservableCollection<int> Categorie
        {
            get { return _categorie; }
            set { _categorie = value; }
        }
        [XmlIgnore]
        public object SelectetProgrammCategorieIds
        {
            get { return (Object)Categorie; }
            set {                 Categories = new ObservableCollection<int>((value as IEnumerable<Object>).ToObservableCollection<int>()) { };
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string VersionsName
        {
            get { return _versionsname; }
            set { _versionsname = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Error
        {
            get;
            set;
        }
        public string this[string columnName]
        {
            get
            {
                Error = string.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(Name))
                        {
                            Error = "Error";
                        }
                        break;
                    case "SelectetProgrammCategorieId":
                        if (DataStoreSingelton.Instance.AlleCategories.FirstOrDefault(S => ((List<int>)SelectetProgrammCategorieIds).FirstOrDefault(s => s == S.ID) == S.ID) != null)
                        {
                            Error = "Please enter a vaild programm categorie";
                        }
                        break;
                    default: break;
                }
                return Error;
            }
        }
    }
        }
