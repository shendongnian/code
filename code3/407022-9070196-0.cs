      using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.IO;
    using System.Data;
    
    namespace xmlCustomReformat
    {
        class importXml
        {
           public DataTable _ComboDataTable;
        public void ExportAutoToText()
        {
            DirectoryInfo AutoDir = new DirectoryInfo(FilePrep.AutoDirectory);
            CreateDataTable(); // set column headers
           foreach (FileInfo File in AutoDir.GetFiles())
           {
               DataRow fileRow = _ComboDataTable.NewRow();
               XDocument xmlDoc = XDocument.Load(AutoDir + File.Name);
               InsuredOrPrincipal[] insured = xmlDoc.Root
                   .Descendants("InsuredOrPrincipal")
                   .Select(x => new InsuredOrPrincipal(x))
                   .Where(ip => ip.InsuredOrPrincipalInfo.InsuredOrPrincipalRoleCd == "Insured")
                   .ToArray();
               foreach (var person in insured)
               {
                   fileRow["First_Name"] = person.GeneralPartyInfo.NameInfo.PersonName.GivenName;
                   fileRow["Last_name"] = person.GeneralPartyInfo.NameInfo.PersonName.Surname;
                   fileRow["Address1"] = person.GeneralPartyInfo.Addr.Address1;
                   fileRow["City"] = person.GeneralPartyInfo.Addr.City;
                   fileRow["State"] = person.GeneralPartyInfo.Addr.State;
                   fileRow["Zip"] = person.GeneralPartyInfo.Addr.Zip;
                   fileRow["Address2"] = " ";
                   fileRow["Zip4"] = " ";
                   fileRow["Match_File"] = File.Name.ToString();
                   _ComboDataTable.Rows.Add(fileRow);
               }
           }
        }
        public void ExportHomeToText()
        {
            DirectoryInfo HomeDir = new DirectoryInfo(FilePrep.HomeDirectory);
            foreach (FileInfo File in HomeDir.GetFiles())
            {
                DataRow fileRow = _ComboDataTable.NewRow();
                XDocument xmlDoc = XDocument.Load(HomeDir + File.Name);
                InsuredOrPrincipal[] insured = xmlDoc.Root
                    .Descendants("InsuredOrPrincipal")
                    .Select(x => new InsuredOrPrincipal(x))
                    .Where(ip => ip.InsuredOrPrincipalInfo.InsuredOrPrincipalRoleCd == "Insured")
                    .ToArray();
                foreach (var person in insured)
                {
                    fileRow["First_Name"] = person.GeneralPartyInfo.NameInfo.PersonName.GivenName;
                    fileRow["Last_name"] = person.GeneralPartyInfo.NameInfo.PersonName.Surname;
                    fileRow["Address1"] = person.GeneralPartyInfo.Addr.Address1;
                    fileRow["City"] = person.GeneralPartyInfo.Addr.City;
                    fileRow["State"] = person.GeneralPartyInfo.Addr.State;
                    fileRow["Zip"] = person.GeneralPartyInfo.Addr.Zip;
                    fileRow["Address2"] = " ";
                    fileRow["Zip4"] = " ";
                    fileRow["Match_File"] = File.Name.ToString();
                    _ComboDataTable.Rows.Add(fileRow);
                }
            }
            ExportDataTable.Write(_ComboDataTable, HomeDir.Parent.FullName.ToString());
        }
        public void CreateDataTable()
        {
            _ComboDataTable = new DataTable();
            _ComboDataTable.Columns.Add("First_Name", typeof(string));
            _ComboDataTable.Columns.Add("Last_Name", typeof(string));
            _ComboDataTable.Columns.Add("Address1", typeof(string));
            _ComboDataTable.Columns.Add("Address2", typeof(string));
            _ComboDataTable.Columns.Add("City", typeof(string));
            _ComboDataTable.Columns.Add("State", typeof(string));
            _ComboDataTable.Columns.Add("Zip", typeof(string));
            _ComboDataTable.Columns.Add("Zip4", typeof(string));
            _ComboDataTable.Columns.Add("Match_File", typeof(string));  
        }
    }
