    private void DisableEnableShippingFieldsValidations(bool enableFields)
    {
        if (enableFields)
            ckBilling.CausesValidation = false;
        else
            ckBilling.CausesValidation = true;
    }
