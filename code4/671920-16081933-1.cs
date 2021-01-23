    public class AuditInterceptor : EmptyInterceptor
    {
        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            var auditableEntity = entity as IAudit;
            if (auditableEntity != null)
            {
                auditableEntity.ModifiedTime = DateTime.Now;
                // ...
            }
    
            return base.OnSave(entity, id, state, propertyNames, types);
        }
    // ...
    }
