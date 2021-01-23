    public static Form ActiveForm
    {
        get
        {
            return Form.ActiveForm == null ? null :
                Form.ActiveForm is MsgBox ? ((MsgBox)Form.ActiveForm).Parent :
                Form.ActiveForm;
        }
    }
