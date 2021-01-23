			@model MetaDataPortal.Models.AnswerScheme
			@Html.HiddenFor(model => model.Id, new { Id = "AnswerSchemeId" })
				<ul class="ulGeneralForm">
					<li>
						@Html.LabelFor(model => model.Name, "Name", new { @class = "labelGeneral" })
						@Html.TextBoxFor(model => model.Name, Model.Name, new { @class = "textBoxGeneral" })
					</li>
					<li>
						@Html.Label(@Model.IsMissing ? "Missings" : "Answers", new { @class = "labelGeneral" })
						<table class="textualData links downloadList">
							<thead>
								<tr>
									<th>Value</th>
									<th> @(Model.IsMissing ? "Missing" : "Answer")</th>
									<th></th>
								</tr>
							</thead>
							<tbody id="tbodyCodeContainer">
								@for (int i = 0; i < Model.Answers.Count; i++) {
									<tr>
										<td>
											@Html.HiddenFor(model => Model.Answers[i].IsMissing)
											@Html.TextBoxFor(model => Model.Answers[i].Value, new { @class = "inputValue" })
										</td>
										<td>
											@Html.TextBoxFor(model => Model.Answers[i].Text, new { @class = "inputAnswer" })
										</td>
										<td><span class="span-delete" data-answer-scheme-id="@Model.Id" data-answer-id="@Model.Answers[i].Id" >x</span></td>
									</tr>
								}
							</tbody>
						</table>
					</li>
				</ul>
