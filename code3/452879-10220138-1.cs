    SqlCommand ucmd = new SqlCommand("Res_invpush_UpdateInv", Con);
                        ucmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter LastChange = new SqlParameter("@NewLastSysChangeVersion", SqlDbType.Int);
                        LastChange.Value = NewSysChangeVersionParam;
                        SqlParameter SubscriptionId = new SqlParameter("InventoryPushSubscriptionId", SqlDbType.Int);
