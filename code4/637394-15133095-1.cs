    @model MyViewModel
    @using (Html.BeginForm()) {
        @Html.ValidationSummary(true)
        <fieldset>
               @Html.LabelFor(x => x.Book.Name , "Book Name")
               @Html.TextBoxFor(x => x.Book.Name, new { name = "Name" })
               @Html.LabelFor(x => x.Book.Author)
               @Html.TextBoxFor(x => x.Book.Author , new { name = "Author" })
               @Html.LabelFor(x => x.Book.PublicationDate ,"Publication Date")
               @Html.TextBoxFor(x => x.Book.PublicationDate , new { name = "PublicationDate" })
               @Html.LabelFor(x => x.SelectedCategoryId , "Select category")
               @Html.DropDownListFor(x => x.SelectedCategoryId, new SelectList(Model.Categories, "Id", "Name")) 
               @Html.LabelFor(x => x.Book.Description)
               @Html.TextAreaFor(x => x.Book.Description ,  new { name = "Description" })
            <p>
                <input type="submit" value="Create" class="link"/>
                @Html.ActionLink("Back to List", "Index", "ProductManager", null, new { @class ="link"})
            </p>
        </fieldset>
    }
