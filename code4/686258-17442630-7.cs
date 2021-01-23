	public virtual JsonResult AdministratorsLoad([DataSourceRequestAttribute]DataSourceRequest request)
		{
			request.Deflatten();
			var administrators = this._administartorRepository.Table;
			var result = administrators.ToDataSourceResult(
				request,
				data => new AdministratorGridItemViewModel { Id = data.Id, User_Email = data.User.Email, User_UserName = data.User.UserName, });
			return this.Json(result);
		}
