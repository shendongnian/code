		static public long Insert(BillAO ao)
		{
			try
			{
				SqlParameter[] Params =
				{
					new SqlParameter("@Status",ao.Status)
					, new SqlParameter("@BAID",ao.BAID)
					, new SqlParameter("@PhieuKhamID",ao.PhieuKhamID)
					, new SqlParameter("@ThuNganID",ao.ThuNganID)
					, new SqlParameter("@Ngay",ao.Ngay)
					, new SqlParameter("@SoTien",ao.SoTien)
					, new SqlParameter("@LyDo",ao.LyDo)
					, new SqlParameter("@GhiChu",ao.GhiChu)
					, new SqlParameter("@CreatedBy",ao.CreatedBy)
					, new SqlParameter("@CreatedTime",ao.CreatedTime)
					, new SqlParameter("@LastModifiedBy",ao.LastModifiedBy)
					, new SqlParameter("@LastModifiedTime",ao.LastModifiedTime)
				};
				int result = int.Parse(SqlHelper.ExecuteScalar(HYPO.Utils.Config.ConnString, CommandType.StoredProcedure, "SP_Bill_Insert", Params).ToString());
				return result;
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("duplicate"))
				{
					return -2;
				}
				return -1;
			}
		}
