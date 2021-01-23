    // This is your strongly typed view that will use
    // model binding to bind the properties of RegisterModel
    // to the View.
    @model Trainer.Models.RegisterModel
    
    // You can find these scripts in default projects in Visual Studio, if you are
    // not using VS, then you can still find them online
    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
    
    // This is where your form starts
    // The "Account" parameter states what controller to post the form to
    @using (Html.BeginForm((string)ViewBag.FormAction, "Account")) {
        @Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.")
    
        <fieldset>
            <legend>Registration Form</legend>
            <ol>
                <li>
                    @Html.LabelFor(m => m.UserName)
                    @Html.TextBoxFor(m => m.UserName)
                    @Html.ValidationMessageFor(m => m.UserName)
                </li>
                <li>
                    @Html.LabelFor(m => m.Email)
                    @Html.TextBoxFor(m => m.Email)
                    @Html.ValidationMessageFor(m => m.Email)
                </li>
                <li>
                    @Html.LabelFor(m => m.Password)
                    @Html.PasswordFor(m => m.Password)
                    @Html.ValidationMessageFor(m => m.Password)
                </li>
                <li>
                    @Html.LabelFor(m => m.ConfirmPassword)
                    @Html.PasswordFor(m => m.ConfirmPassword)
                    @Html.ValidationMessageFor(m => m.ConfirmPassword)
                </li>
            </ol>
            <!-- The value property being set to register tells the form
                 what method of the controller to post to -->
            <input type="submit" value="Register" /> 
        </fieldset>
    }
