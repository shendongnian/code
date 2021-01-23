     public static bool AddMemberPanels(List<int> panelIDs, Guid memberId, int status)
        {
            try
            {
                using (FairShareEntities fairShareEntities = new FairShareEntities())
                {
                    foreach (var panelId in panelIDs)
                    {
                        //get the member and panels
                        Member theMember =
                            (from m in fairShareEntities.Member.Include("MemberPanel") where m.UserId == memberId select m).FirstOrDefault();
                        //see if this Member is already on this Panel
                        if (!(from mp in theMember.MemberPanel where mp.PanelId == panelId select mp).Any())
                        {
                            //get the panel
                            Panel thePanel = (from p in fairShareEntities.Panel where p.PanelId == panelId select p).FirstOrDefault();
                            //add the panel to this Member
                            MemberPanel addMemberPanel = new MemberPanel()
                            {
                                UserId = memberId,
                                Status = status,
                                Panel = thePanel,
                                PanelId = panelId
                            };
                            theMember.MemberPanel.Add(addMemberPanel);
                            fairShareEntities.SaveChanges();
                        }
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
