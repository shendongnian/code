	public IEnumerable<StaffJoin> GetOrderStaffByDepartment(int DepID, DateTime DATE)
	{
		using (var Context = new CRMDBEntities())
		{
			IQueryable<Promotion> result = (from pro2 in Context.tbl_Promotion
									where pro2.PromotionDate <= DATE && pro2.DepID==DepID
									select pro2);
	
			IQueryable<Promotion> result2 = (from Re in result
									group Re by Re.StaffID into g2
									join prop in Context.tbl_Promotion on g2.Max(c => c.PromotionID) equals prop.PromotionID
									select prop);
	
			var result3 = (from s in Context.tbl_STaff
						join
						promotion in result2 on s.StaffID equals promotion.StaffID
						join
						position in Context.tbl_Position on promotion.PositionID equals position.PositionID
						select new StaffJoin{Staff= s,Promotion= promotion,Position= position}).ToList();
	
			return result3;
		}
	}
