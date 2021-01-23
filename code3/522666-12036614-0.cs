    var somedata = (from TblKDMS_conf in this._db.GetTable<KDMS_configuration>()
                  where TblKDMS_conf.SystemID == TblKDMSConfig.SystemID select TblKDMS_conf.ConfigurationDate).Max();
    Queryable<getKDMS> query = (from VD in this._db.GetTable<KDMS_dynamic>()
                                        join TblKDMS in this._db.GetTable<KDMS_definition>() on VD.SystemID equals TblKDMS.SystemID
                                        join TblKDMSType in this._db.GetTable<KDMS_typeid>().DefaultIfEmpty() on TblKDMS.TypeID equals TblKDMSType.TypeID 
                                        join TblKDMSConfig in this._db.GetTable<KDMS_configuration>() on new {TblKDMS.SystemID,TblKDMSConfig.ConfigurationDate} equals new{TblKDMSConfig.SystemID,somedata}
