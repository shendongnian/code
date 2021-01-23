	  @model IEnumerable<SampleECommerce.Models.DetailsModel>
	  @using (Html.BeginForm("Details", "Grid", new { UserID = Request.QueryString["UserID"], partnerid = Request.QueryString["Partnerid"] }, FormMethod.Post))
		{
			<table>
				@foreach (var item in Model)
				{
						<tr>
							<td>
								@Html.DisplayNameFor(model => model.FirstName)
								<input id="MFirstName" type="text" class="TextBoxBorder" name="FirstName" value="@item.FirstName" />
							</td>
						</tr>
				}
			</table>
		}
