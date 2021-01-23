        private void btnGroupNameLookup_Click(object sender, EventArgs e)
        {
            //instantiate an instance of the grp name lookup form
            frmGroupNameLookup lookupName = new frmGroupNameLookup();
            //add an event handler to update THIS form when the lookup
            //form is updated. (This is when LookupUpdated fires
            lookupName.GroupNamesFound += new frmGroupNameLookup.LookupHandler(lookupName_GroupNamesFound);
            //rc.ReconCFUpdated += new ReconCaseFileChecklist.ReconCFListHandler(ReconCFForm_ButtonClicked);
            lookupName.Show();
        }
        void lookupName_GroupNamesFound(object sender, GroupNameLookupUpdateEventArgs e)
        {
            //update the list boxes here            
            foreach (string s in e.Parents)
            {
                lstFilteredGroupParents.Items.Add(s);
            }
            foreach (string s in e.Groups)
            {
                lstFilteredGroups.Items.Add(s);
                //link supgroups and plan ids
                GetFilteredSubgroupNos(s);
                GetFilteredPlanIds(s);
            }
            //ensure dupes are stripped out
            //filter out duplicates 
            var noDupeSubgroups = subgroupList.Distinct().ToList();
            noDupeSubgroups.Sort();
            foreach (string s in noDupeSubgroups)
            {
                lstFilteredSubgroups.Items.Add(s);
            }
            var noDupePlanIDs = planIDList.Distinct().ToList();
            noDupePlanIDs.Sort();
            foreach (string s in noDupePlanIDs)
            {
                lstFilteredPlanID.Items.Add(s);
            }
        }
