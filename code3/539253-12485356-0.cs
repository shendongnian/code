    private void SyncKinases()
    {
        DataSet ds = new DataSet();
        ds = gn.ExecuteQuery("dx.kinasedatasheet.selectstagingkinases", null);
        TreeProvider tp = new TreeProvider(ui);
        VersionManager vm = new VersionManager(tp);
        TreeNode node;
        WorkflowManager wm = new WorkflowManager(tp);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string className = "dx.kinasedatasheet";
                string title = dr["Title"].ToString();
                string technologyPlatform = dr["TechnologyPlatform"].ToString();
                string ambitGeneSymbol = dr["AmbitGeneSymbol"].ToString();
                string targetDescription = dr["TargetDescription"].ToString();
                string entrezGeneSymbol = dr["EntrezGeneSymbol"].ToString();
                int entrezGeneID = int.Parse(dr["EntrezGeneID"].ToString());
                string aliases = dr["Aliases"].ToString();
                string kinaseGroup = dr["KinaseGroup"].ToString();
                string species = dr["Species"].ToString();
                string accessionNumber = dr["AccessionNumber"].ToString();
                string kinaseConstruct = dr["KinaseConstruct"].ToString();
                string kinaseForm = dr["KinaseForm"].ToString();
                string expressionSystem = dr["ExpressionSystem"].ToString();
                double avgZValue = 0;
                if (!(dr["AverageZValue"] is DBNull))
                {
                    avgZValue = double.Parse(dr["AverageZValue"].ToString());
                }
                string panel = dr["Panel"].ToString();
                string compoundsKds = dr["CompoundsKds"].ToString();
                string mutationRelevance = dr["MutationRelevance"].ToString();
                string mutationReferences = dr["MutationReferences"].ToString();
                string kinaseAliasPath = "/Kinase-Data-Sheets";
				bool isNewNode = false;
                if (!(dr["NodeID"] is System.DBNull))
                {
                    node = tp.SelectSingleNode(int.Parse(dr["NodeID"].ToString()));
                    vm.CheckOut(node);
                }
                else
                {
                    node = TreeNode.New(className, tp);
                    node.SetValue("DocumentCulture", "en-US");
					isNewNewNode = true;
                }
				node.DocumentName = ambitGeneSymbol;
				node.NodeName = ambitGeneSymbol;
				node.SetValue("Title", title);
				node.SetValue("TechnologyPlatform", technologyPlatform);
				node.SetValue("AmbitGeneSymbol", ambitGeneSymbol);
				node.SetValue("TargetDescription", targetDescription);
				node.SetValue("EntrezGeneSymbol", entrezGeneSymbol);
				node.SetValue("EntrezGeneID", entrezGeneID);
				node.SetValue("Aliases", aliases);
				node.SetValue("KinaseGroup", kinaseGroup);
				node.SetValue("Species", species);
				node.SetValue("AccessionNumber", accessionNumber);
				node.SetValue("KinaseConstruct", kinaseConstruct);
				node.SetValue("KinaseForm", kinaseForm);
				node.SetValue("ExpressionSystem", expressionSystem);
				if (!(dr["AverageZValue"] is DBNull))
				{
					node.SetValue("AverageZValue", avgZValue);
				}
				node.SetValue("Panel", panel);
				node.SetValue("CompoundsKds", compoundsKds);
				node.SetValue("MutationRelevance", mutationRelevance);
				node.SetValue("MutationReferences", mutationReferences);
				node.SetValue("DocumentPublishTo", null);
				if (isNewNode)
				{
                    TreeNode parentNode = tp.SelectSingleNode("DiscoveRx", kinaseAliasPath, "en-US");
                    node.Insert(parentNode);
                    //vm.CheckIn(node, null, null);
                    newKinaseCount++;
				}
				else
				{
                    node.Update();
                    updatedKinaseCount++;
                    vm.CheckIn(node, null, null);
                    WorkflowInfo wi = wm.GetNodeWorkflow(node);
                    if (node.IsPublished)
                    {
                        wm.AutomaticallyPublish(node, wi, null);
                    }
				}
            }
        }
        ArchiveItems(archivedKinaseCount, "dx.kinasedatasheet.selectarchivekinases");
    }
