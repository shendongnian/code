            foreach (AOTLuAffinity oAffinity in oAotluAffinity)
            {
                if (oAffinity.Name == comboName.SelectedValue.ToString())
                {
                    isAllow = oAffinity.isAllowName;
                    signCard = AOTHelper.GetHasSigCardValue(workflowid, Acct.AffinityNum, comboPaBranch.SelectedValue.ToString(), Applicants.AffinityNum, isSignCard, isAllow );
                    
                    chkBrand.Checked = 
                                       peopleList
                                       .Count(c => c.Name ==  comboName.SelectedValue.ToString()) > 0 ? true : false;
                    break;
                }
            }
