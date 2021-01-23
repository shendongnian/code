        CustomValidator customValidator = new CustomValidator();
        customValidator.ControlToValidate = textBox.ID;
        customValidator.ClientValidationFunction = "changeColorofTextBox";
        customValidator.ValidateEmptyText = true;
        customValidator.EnableClientScript = true;
        e.Item.Controls.Add(customValidator);
