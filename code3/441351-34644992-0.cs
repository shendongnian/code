    foreach (var prop in ViewData.ModelMetadata.Properties.Where(pm => !pm.HideSurroundingHtml && pm.ShowForEdit && !ViewData.TemplateInfo.Visited(pm))) {
	<div class="form-group">
		<label>
			@prop.GetDisplayName() 
			@if (prop.IsRequired)
			{
				<span class="required">*</span>
			}
		</label>
		@Html.Editor(prop.PropertyName)
		@Html.ValidationMessage(prop.PropertyName, new {@class = "help-block"})
	</div>
}
