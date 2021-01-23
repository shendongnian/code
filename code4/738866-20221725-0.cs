            var paretnCodeValidation = codeSheet.DataValidations.AddTextLengthValidation("B:B");
            paretnCodeValidation.ShowErrorMessage = true;
            paretnCodeValidation.ErrorStyle = ExcelDataValidationWarningStyle.stop;
            paretnCodeValidation.ErrorTitle = "An invalid value was entered";
            paretnCodeValidation.Error = "Parent must be between 1 and 50 digits in length";
            paretnCodeValidation.Formula.Value = 1;
            paretnCodeValidation.Formula2.Value = 50;
