            tvTree.Nodes.Add("Subjects", "Subjects");
            tvTree.Nodes["Subjects"].Nodes.Add("Physics", "Physics");
            var phyNode = tvTree.Nodes.Find("Physics", true).First();
            phyNode.Nodes.Add("PhysicsP1", "Paper1");
            phyNode.Nodes.Add("PhysicsP2", "Paper2");
            phyNode.Nodes.Add("PhysicsP3", "Paper3");
