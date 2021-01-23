    private void DisableEnableShippingFieldsValidations(bool enableFields)
    {
        if (enableFields)
            ckSameBilling.CausesValidation = false;
        else
            ckSameBilling.CausesValidation = true;
    }
