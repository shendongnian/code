            var urns = new List<Urn>();
            Scripter schemaScripter = new Scripter(srv) { Options = schemaOptions };
            Scripter insertScripter = new Scripter(srv) { Options = insertOptions };
            var dw = new DependencyWalker(srv);
            foreach (Table t in db.Tables)
                if (t.IsSystemObject == false)
                    urns.Add(t.Urn);
            DependencyTree dTree = dw.DiscoverDependencies(urns.ToArray(), true);
            DependencyCollection dColl = dw.WalkDependencies(dTree);
            foreach (var d in dColl)
            {
                foreach (var s in schemaScripter.Script(new Urn[] { d.Urn }))
                    strings.Add(s);
                strings.Add("GO");
                if (scriptData)
                {
                    int n = 0;
                    foreach (var i in insertScripter.EnumScript(new Urn[] {d.Urn}))
                    {
                        strings.Add(i);
                        if ((++n) % 100 == 0)
                            strings.Add("GO");
                    }
                }
            }
