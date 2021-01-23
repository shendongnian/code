    using Accounting.Domain.Concrete;
    using Accounting.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Design.PluralizationServices;
    using System.Data.Entity.Migrations;
    using System.Data.Odbc;
    using System.Globalization;
    using System.Linq;
    
    namespace QuickBooks.Services
    {
        public class QuickBooksSynchService
        {
            string qodbcConnectionString = @"DSN=QuickBooks Data;SERVER=QODBC;OptimizerDBFolder=%UserProfile%\QODBC Driver for QuickBooks\Optimizer;OptimizerAllowDirtyReads=N;SyncFromOtherTables=Y;IAppReadOnly=Y";
            PluralizationService pluralizationService = PluralizationService.CreateService(CultureInfo.CurrentCulture);
            readonly int companyID;
    
            public QuickBooksSynchService(string companyName)
            {
                // Make sure the name of QODBC company is same as passed in
                using (var con = new OdbcConnection(qodbcConnectionString))
                using (var cmd = new OdbcCommand("select top 1 CompanyName from Company", con))
                {
                    con.Open();
                    string currentCompany = (string)cmd.ExecuteScalar();
                    if (companyName != currentCompany)
                    {
                        throw new Exception("Wrong company - expecting " + companyName + ", got " + currentCompany);
                    }
                }
    
                // Get the company ID using the name passed in (row with matching name must exist)
                using (var repo = new AccountingRepository(new AccountingContext(), true))
                {
                    this.companyID = repo.CompanyFileByName(companyName).CompanyId;
                }
            }
    
            public IEnumerable<T> Extract<T>() where T : new()
            {
                using (var con = new OdbcConnection(qodbcConnectionString))
                using (var cmd = new OdbcCommand("select * from " + typeof(T).Name, con))
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var t = new T();
    
                        // Set half of the primary key
                        typeof(Customer).GetProperty("CompanyId").SetValue(t, this.companyID, null);
    
                        // Initialize all DateTime fields
                        foreach (var datePI in from p in typeof(Customer).GetProperties()
                                               where p.PropertyType == typeof(DateTime)
                                               select p)
                        {
                            datePI.SetValue(t, new DateTime(1900, 1, 1), null);
                        }
    
                        // Auto-map the fields
                        foreach (var colName in from c in reader.GetSchemaTable().AsEnumerable()
                                                select c.Field<string>("ColumnName"))
                        {
                            object colValue = reader[colName];
                            if ((colValue != DBNull.Value) && (colValue != null))
                            {
                                typeof(Customer).GetProperty(colName).SetValue(t, colValue, null);
                            }
                        }
    
                        yield return t;
                    }
                }
            }
    
            public void Load<T>(IEnumerable<T> ts, bool save) where T : class
            {
                using (var context = new AccountingContext())
                {
                    var dbSet = context
                                    .GetType()
                                    .GetProperty(this.pluralizationService.Pluralize(typeof(T).Name))
                                    .GetValue(context, null) as DbSet<T>;
    
                    if (dbSet == null)
                        throw new Exception("could not cast to DbSet<T> for T = " + typeof(T).Name);
    
                    foreach (var t in ts)
                    {
                        dbSet.AddOrUpdate(t);
                    }
    
                    if (save)
                    {
                        context.SaveChanges();
                    }
                }
            }
        }
    }
