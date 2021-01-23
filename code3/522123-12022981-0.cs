            System.Data.Common.DbTransaction transaction = null;
            DBDataContext db = new DBDataContext();
            db.Connection.Open();
            transaction = db.Connection.BeginTransaction();
            db.Transaction = transaction;
            Table1 = new Table1();
            obj.objName = "some name";
            db.Table1s.InsertOnSubmit(obj);
            db.SubmitChanges();
            Table2 obj_info = new Table2();
            obj_info.Info = "some info";
            obj_info.Id = obj.Id;
            db.Table2s.InsertOnSubmit(obj_info);
            db.SubmitChanges();
            try
            {
                db.SubmitChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                db.Dispose();
            }
