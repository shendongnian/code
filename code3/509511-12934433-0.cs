        public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
        {
            var changes = GetChangeSet();
            var inserts = changes.Inserts;
            var deletes = changes.Deletes;
            var updates = changes.Updates;
            var sbLog = new StringBuilder();
            sbLog.AppendLine("Inserts:");
            sbLog.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(inserts, Newtonsoft.Json.Formatting.Indented,
                new Newtonsoft.Json.JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore }));
            sbLog.AppendLine("Deletes:");
            sbLog.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(deletes, Newtonsoft.Json.Formatting.Indented,
                new Newtonsoft.Json.JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore }));
            sbLog.AppendLine("Updates:");
            foreach(object x in updates) {
                var original = this.GetTable(x.GetType()).GetOriginalEntityState(x);
                sbLog.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(new { original = original, mod = x },
                    Newtonsoft.Json.Formatting.Indented,
                    new Newtonsoft.Json.JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore }));
            }
            //"logger" can be anything, you use to log the changes...
            logger.Info(("db operations:" + Environment.NewLine + sbLog.ToString()).Replace(Environment.NewLine, Environment.NewLine + " | "));
            base.SubmitChanges(failureMode);
         }
