        //creation of new changelist 
        public Changelist CreateNewChangelistInWorkspace(string workspace_name, string change_description)
        {
            Repository rep = P4Core.Instance.GetRepository(workspace_name);
            Client client = rep.GetClient(workspace_name);
            client.Host = string.Empty;
            rep.UpdateClient(client);
            //creating changelist
            Changelist cl = new Changelist();
            cl.Description = change_description;
            cl.ClientId = workspace_name;
            cl = rep.CreateChangelist(cl);
            return cl;
        }
