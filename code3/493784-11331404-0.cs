       public virtual void UpdateBankAccountUsingParseXML_SP(System.Xml.Linq.XElement inputXML)
        {
            string connectionstring = "Data Source=.;Initial Catalog=LibraryReservationSystem;Integrated Security=True;Connect Timeout=600";
            var myDataContext = new DBML_Project.MyDataClassesDataContext(connectionstring);
            myDataContext.ParseXML(inputXML);
        }
        public void FreezeAllAccountsForUser(int userId)
        {
            List<DTOLayer.BankAccountDTOForStatus> bankAccountDTOList = new List<DTOLayer.BankAccountDTOForStatus>(); 
            
            IEnumerable<DBML_Project.BankAccount> accounts = AccountRepository.GetAllAccountsForUser(userId);
            foreach (DBML_Project.BankAccount acc in accounts)
            {
                string typeResult = Convert.ToString(acc.GetType());
                string baseValue = Convert.ToString(typeof(DBML_Project.BankAccount));
                if (String.Equals(typeResult, baseValue))
                {
                    throw new Exception("Not correct derived type");
                }
                acc.Freeze();
                DTOLayer.BankAccountDTOForStatus presentAccount = new DTOLayer.BankAccountDTOForStatus();
                presentAccount.BankAccountID = acc.BankAccountID;
                presentAccount.Status = acc.Status;
                bankAccountDTOList.Add(presentAccount);
            }
            IEnumerable<System.Xml.Linq.XElement> el = bankAccountDTOList.Select(x =>
                            new System.Xml.Linq.XElement("BankAccountDTOForStatus",
                              new System.Xml.Linq.XElement("BankAccountID", x.BankAccountID),
                              new System.Xml.Linq.XElement("Status", x.Status)
                            ));
            System.Xml.Linq.XElement root = new System.Xml.Linq.XElement("root", el);
            AccountRepository.UpdateBankAccountUsingParseXML_SP(root);
            //AccountRepository.Update();
        }
