          using (var mycontext = new context())
            {
               SkillsAssestUser assestUser = new SkillsAssestUser();
               assestUser.DomainAcc = lblDomAcc.Text;
               assestUser.Name = txtName.Text;
               assestUser.Surname = txtSurname.Text;
               assestUser.Division = txtDivision.Text;
               assestUser.Manager = txtManager.Text;
               mycontext.SkillsAssestUsers.Add(assestUser);
               mycontext.SaveChanges();
            }
