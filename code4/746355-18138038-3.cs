            public interface IEntity
                {
                    int Id { get; set; }
                }
            
             public interface IAuditable : IEntity
                {
                    string UpdatedBy { get; set; }
                    string CreatedBy { get; set; }
                    DateTime CreatedDate { get; set; }
                    DateTime UpdateDate { get; set; }
                }
        
        Now any entity which is auditable will implement this class your context will look the following
        
        
               
            
                public class MYContext : DbContext, ILicensingContext
                {
                    private readonly IAuditLogBuilder _auditLogBuilder;
            
            
                    public LicensingContext()
                        : this(new AuditLogBuilder())
                    {
                    }
                    private IDbSet<Device> Devices { get; set; }
            
                    private IDbSet<AuditLog> AuditLogs { get; set; }
            
                          
                    public MyContext(IAuditLogBuilder auditLogBuilder)
                    {
                        _auditLogBuilder = auditLogBuilder;
                    }
            
            
            
                    /// <summary>
                    ///     1. Constructs the AuditLog objects from the context
                    ///     2. Calls SaveChanges to save the actual object modified
                    ///     3. It updates the Log objects constructed in step 1 to populate the IDs returned from the Db
                    ///     4. Saves the AuditLogs
                    /// </summary>
                    /// <returns></returns>
                    public override int SaveChanges()
                    {
                        var entries = ChangeTracker.Entries<IAuditable>().ToList();
            
                        _auditLogBuilder.UpdateAuditables(entries);
                        IEnumerable<AuditLog> auditLogEntities = _auditLogBuilder.ConstructAuditLogs(entries).ToList();
            
            
                        int countOfAffectedRecords = base.SaveChanges();
            
                        _auditLogBuilder.UpdateAuditLogs(auditLogEntities);
                        foreach (AuditLog auditLogEntity in auditLogEntities)
                        {
                            GetDbSet<AuditLog>().Add(auditLogEntity);
                        }
                        base.SaveChanges();
                        return countOfAffectedRecords;
                    }
            
            
                    public IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
                    {
                        return Set<TEntity>();
                    }
                }
    
     public class AuditLogBuilder : IAuditLogBuilder
        {
            private string _username;
    
            private string Username
            {
                get
                {
                    if (HttpContext.Current != null && HttpContext.Current.User != null)
                    {
                        _username = HttpContext.Current.User.Identity.Name;
                    }
    
                    if (String.IsNullOrWhiteSpace(_username))
                    {
                        _username = "Service Consumer";
                    }
                    return _username;
                }
            }
    
            public IEnumerable<AuditLog> ConstructAuditLogs(IEnumerable<DbEntityEntry<IAuditable>> auditableEntities)
            {
                var audits = new List<AuditLog>();
                if (auditableEntities != null)
                {
                    audits.AddRange(auditableEntities
                                    .Where(
                                         e =>
                                         e.State == EntityState.Modified || e.State == EntityState.Added ||
                                        e.State == EntityState.Deleted)
                               .SelectMany(GetAuditLogs));
                }
                return audits;
            }
    
            public void UpdateAuditLogs(IEnumerable<AuditLog> auditLogEntities)
            {
                foreach (AuditLog auditLog in auditLogEntities)
                {
                    auditLog.RecordId = auditLog.Entity.Id;
                    auditLog.UpdatedBy = auditLog.Entity.UpdatedBy;
    
                    if (String.Equals(auditLog.PropertyName, "id", StringComparison.CurrentCultureIgnoreCase))
                    {
                        auditLog.NewValue = auditLog.Entity.Id.ToString(CultureInfo.CurrentCulture);
                    }
                }
            }
    
            public void UpdateAuditables(IEnumerable<DbEntityEntry<IAuditable>> entries)
            {
                if (entries != null)
                {
                    foreach (var entry in entries)
                    {
                        entry.Entity.UpdateDate = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = Username;
                        if (entry.Entity.Id == 0)
                        {
                            entry.Entity.CreatedDate = DateTime.UtcNow;
                            entry.Entity.CreatedBy = Username;
                        }
                    }
                }
            }
    
            private static IEnumerable<AuditLog> GetAuditLogs(DbEntityEntry<IAuditable> entry)
            {
                var audits = new List<AuditLog>();
    
                string entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
    
                switch (entry.State)
                {
                    case EntityState.Added:
    
                        audits.AddRange(entry.CurrentValues.PropertyNames.Select(propertyName =>
                                                                                 new AuditLog
                                                                                     {
                                                                                         EntityName = entityName,
                                                                                         CreateDate = DateTime.UtcNow,
                                                                                         NewValue =
                                                                                             entry.CurrentValues[
                                                                                                 propertyName] != null
                                                                                                 ? entry.CurrentValues[
                                                                                                     propertyName].ToString()
                                                                                                 : String.Empty,
                                                                                         PreviousValue = String.Empty,
                                                                                         PropertyName = propertyName,
                                                                                         Entity = entry.Entity,
                                                                                         Action = Actions.Create.ToString()
                                                                                     }));
                        break;
    
                    case EntityState.Deleted:
                        audits.AddRange(entry.OriginalValues.PropertyNames.Select(propertyName =>
                                                                                  new AuditLog
                                                                                      {
                                                                                          EntityName = entityName,
                                                                                          CreateDate = DateTime.UtcNow,
                                                                                          NewValue = String.Empty,
                                                                                          PreviousValue =
                                                                                              entry.OriginalValues[
                                                                                                  propertyName] != null
                                                                                                  ? entry.OriginalValues[
                                                                                                      propertyName].ToString
                                                                                                        ()
                                                                                                  : String.Empty,
                                                                                          PropertyName = propertyName,
                                                                                          Entity = entry.Entity,
                                                                                          Action = Actions.Delete.ToString()
                                                                                      }));
    
                        break;
    
                    case EntityState.Modified:
    
                        audits.AddRange(entry.OriginalValues.PropertyNames.
                                              Where(
                                                  propertyName =>
                                                  !Equals(entry.OriginalValues[propertyName],
                                                          entry.CurrentValues[propertyName]))
                                             .Select(propertyName =>
                                                     new AuditLog
                                                         {
                                                             EntityName = entityName,
                                                             CreateDate = DateTime.UtcNow,
                                                             NewValue =
                                                                 entry.CurrentValues[propertyName] != null
                                                                     ? entry.CurrentValues[propertyName].ToString()
                                                                     : String.Empty,
                                                             PreviousValue =
                                                                 entry.OriginalValues[propertyName] != null
                                                                     ? entry.OriginalValues[propertyName].ToString()
                                                                     : String.Empty,
                                                             PropertyName = propertyName,
                                                             Entity = entry.Entity,
                                                             Action = Actions.Update.ToString()
                                                         }));
                        break;
                }
                return audits;
            }
        }
