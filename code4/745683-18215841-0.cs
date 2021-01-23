        protected void InsertAuditRecordToDatabase(ModifiedMemberInfo[] changes, object entity)
        {
            Type type = entity.GetType();
            PropertyInfo key;
            key = type.GetProperties()
                .Where(o =>
                    o.GetCustomAttributes(typeof(ColumnAttribute), true)
                        .Any(a => ((ColumnAttribute)a).IsPrimaryKey)).SingleOrDefault();
            AuditRecord audit = new AuditRecord();
            audit.Action = (byte)AuditAction.Update;
            audit.AuditDate = DateTime.Now;
            audit.AssociationTable = null;
            audit.AssociationTableKey = null;
            audit.EntityTable = type.Name;
            audit.EntityTableKey = int.Parse(key.GetValue(entity, null).ToString());
            audit.UserName = HttpContext.Current.User.Identity.Name;
            if (string.IsNullOrEmpty(audit.UserName))
                audit.UserName = "Anonymous";
            foreach (ModifiedMemberInfo mmi in changes)
            {
                AuditRecordField field = new AuditRecordField();
                if (!excludedFieldNamesFromAudit.Any(x => x.Equals(mmi.Member.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    field.MemberName = mmi.Member.Name;
                    field.OldValue = (mmi.OriginalValue != null ? mmi.OriginalValue.ToString() : string.Empty);
                    field.NewValue = (mmi.CurrentValue != null ? mmi.CurrentValue.ToString() : string.Empty);
                    if ((field.OldValue != null && !field.OldValue.Equals(field.NewValue)) ||
                        (field.OldValue == null && field.NewValue != null))
                    {
                        // Special handling
                        if (field.MemberName.Equals("EUAMemberTypeId"))
                        {
                            field.OldValue = GetDescription(this.OrganisationSubTypes, field.OldValue, m => m.Id, m => m != null ? m.Name : string.Empty);
                            field.NewValue = GetDescription(this.OrganisationSubTypes, field.NewValue, m => m.Id, m => m != null ? m.Name : string.Empty);
                        }
                        if (field.MemberName.Equals("ContactPersonStaffId"))
                        {
                            field.OldValue = GetDescription(this.OrganisationStaffs, field.OldValue, m => m.Id, m => m != null ? m.Contact.FullName : string.Empty);
                            field.NewValue = GetDescription(this.OrganisationStaffs, field.NewValue, m => m.Id, m => m != null ? m.Contact.FullName : string.Empty);
                        }
                        if (field.MemberName.Equals("CountryId"))
                        {
                            field.OldValue = GetDescription(this.Countries, field.OldValue, m => m.Id, m => m != null ? m.Name : string.Empty);
                            field.NewValue = GetDescription(this.Countries, field.NewValue, m => m.Id, m => m != null ? m.Name : string.Empty);
                        }
                        // Save it to the DB
                        audit.AuditRecordFields.Add(field);
                    }
                }
            }
            if (audit.AuditRecordFields.Count > 0)
                this.AuditRecords.InsertOnSubmit(audit);
        }
        public static string GetDescription<T, TProp>(Table<T> thisTable, string searchParam, Expression<Func<T, TProp>> searchExpression, Expression<Func<T, string>> descriptionExpression)
            where T : class
        {
            if (!(searchExpression.Body is MemberExpression))
            {
                throw new ArgumentException("Search Expression must be a MemberExpression (i.e v => v.Id)", "searchExpression");
            }
            else
            {
                int searchValue;
                if (int.TryParse(searchParam, out searchValue))
                {
                    var equalityExpression = Expression.Equal(searchExpression.Body, Expression.Constant(searchValue));
                    var lambdaExpression = Expression.Lambda<Func<T, bool>>(equalityExpression, searchExpression.Parameters);
                    // the passed-in expression must resemble v => v.Id
                    // the generated expression will resemble v => v.Id == 5
                    var value = thisTable.SingleOrDefault(lambdaExpression);
                    return descriptionExpression.Compile()(value);
                }
                return string.Empty;
            }
        }
