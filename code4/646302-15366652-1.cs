	@Html.Raw(Model.HeaderTypeRowRenderer.ToHtmlString())
	@{bool reachedSummaryRows = false;}
	@foreach (var response in Model.Responses) {
		if (!reachedSummaryRows && !response.IsPass.HasValue) {
			reachedSummaryRows = true;
			@:@Html.Raw(Model.HeaderTypeRowRenderer.ToHtmlString())
		}
		
		// other table rows here
	}
