     public override bool Save(IPredicate updateRestriction, bool recurse)
        {
            ModifyDatetime = DateTime.Now;
            int userID = 0;
            // Verifies the UserId that called the Save(). Uses 0 (as system user) when none is found.
            try
            {
                if (HttpContext.Current.Session["UserID"] != null)
                { userID = Convert.ToInt32(HttpContext.Current.Session["UserID"]); }
            }
            catch (NullReferenceException nullE)
            {
                userID = 0;
            }
            ModifyUserObjectId = userID;
            return base.Save(updateRestriction, recurse);
        }
        /// <summary> The ModifyDatetime property of all Entities<br/><br/></summary>
        /// <remarks>All tables must have the field: *table*."modifyDatetime"<br/>
        public virtual Nullable<System.DateTime> ModifyDatetime
        {
        //    get { return (Nullable<System.DateTime>)GetValue((int)base.Fields["ModifyDatetime"].FieldIndex, false); }  // uncomment for GET
            set { SetValue((int)base.Fields["ModifyDatetime"].FieldIndex, value, true); }
        }
        /// <summary> The ModifyUserObjectId property of all Entities<br/><br/></summary>
        /// <remarks>All tables must have the field: *table*."modifyUser_objectID"<br/>
        public virtual Nullable<System.Int32> ModifyUserObjectId
        {
        //    get { return (Nullable<System.Int32>)GetValue((int)base.Fields["ModifyUserObjectId"].FieldIndex, false); }  // uncomment for GET
            set { SetValue((int)base.Fields["ModifyUserObjectId"].FieldIndex, value, true); }
        }
