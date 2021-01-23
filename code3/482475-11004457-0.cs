        public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
        {
            bool everythingIsOK = true;
            var changes = GetChangeSet();
            var inserts = changes.Inserts;
            var deletes = changes.Deletes;
            var updates = changes.Updates;
            //verify everything is valid
            //...
            //if you need to, you can get the original state of the updated objects like this:
            foreach(object x in updates) {
                var original = this.GetTable(x.GetType()).GetOriginalEntityState(x);
                //verify the change doesn't break anything
                //...
            }
            if(everythingIsOK){ base.SubmitChanges(failureMode); }
        }
