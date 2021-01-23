    partial void updateRecords_Execute()
        {
            // Write your code here.
           
            using (var tempWorkspace = new DataWorkspace())
            {
                var mymembers = tempWorkspace.ApplicationData.Members;
                //var myscreen = this.Reconcilliations1.SelectedItem.FromMainCompanies.Where(a => a.Member != null).Select(b => b.Member);
                //Member myMember = new Member();
                foreach (Member item in mymembers)
                {
                Saving NewSavings = tempWorkspace.ApplicationData.Savings.AddNew();
                ////var koo = from a in FromMainCompanies
                ////          select a.Member;
                
               
                    NewSavings.CaptureDate = DateTime.Now;
                    NewSavings.Amount = item.Savings.Select(a=>a.Amount).LastOrDefault();
                    NewSavings.FinancialYear = tempWorkspace.ApplicationData.FinancialYears.FirstOrDefault();
                    NewSavings.Member = item;
                    NewSavings.NewSavingsAmount = item.Savings.Select(a=>a.NewSavingsAmount).LastOrDefault();
                }
              
                        
                       
              
                try
                {
                    tempWorkspace.ApplicationData.SaveChanges();
                }
                catch (Exception e)
                {
                    this.ShowMessageBox(e.Message);
                } 
                
            }
            }
