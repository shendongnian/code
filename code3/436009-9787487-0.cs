    using ( var transaction = new TransactionScope() )
            {
                var connection = this.ConnectionManager.GetConnectionstring( AcademyOne.Models.Connection.A1Databases.A1VerwaltungEntity );
                using ( var context = new istis.AcademyOne.Models.Models.A1Verwaltung.VerwaltungModelsContext( connection.Connectionstring ) )
                {
                    foreach ( var seminar in seminare )
                    {
                        context.Seminar.Attach( seminar );
                        //The following line shall be commented out.
                        //context.ObjectStateManager.ChangeObjectState( seminar, StateValueConverter.GetEquivalentEntityState( seminar.ChangeTracker.State ) );
                    }
                    context.SaveChanges( SaveOptions.DetectChangesBeforeSave );
                }             
                transaction.Complete();
            }
